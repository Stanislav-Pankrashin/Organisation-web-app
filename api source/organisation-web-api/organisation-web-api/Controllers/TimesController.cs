using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using organisation_web_api.Api_Models;
using organisation_web_api.Models;

namespace organisation_web_api.Controllers
{
    public class TimeController : ApiController
    {
        public Organisation_model db = new Organisation_model();

        // GET: api/Time
        private IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Time?username={username}
        //public IEnumerable<TimeModel> Get(string username)
        //{
        //    //I know that using two queries isn't the best idea, but the only other alternative would have been to pull the entire times table, this would impact scaling
        //    var result = (from u in db.s_user //get all personal times first
        //                  join gr in db.c_group_relationship on u.user_id equals gr.user_id
        //                  join g in db.c_group on gr.group_id equals g.group_id
        //                  join uce in db.c_user_calendar_entry on u.user_id equals uce.user_id
        //                  join t in db.t_times on uce.time_id equals t.time_id
        //                  join d in db.t_days on t.day_id equals d.day_id
        //                  join hh in db.t_half_hours on t.half_hour_id_start equals hh.half_hour_id
        //                  join hh2 in db.t_half_hours on t.half_hour_id_end equals hh2.half_hour_id
        //                  where u.username == username
        //                  select new TimeModel
        //                  {
        //                      UserName = u.username,
        //                      Day = d.day_text,
        //                      TimeIdStart = t.half_hour_id_start,
        //                      TimeIdEnd = t.half_hour_id_end,
        //                      TimeStart = hh.half_hour_time,
        //                      TimeEnd = hh2.half_hour_time
        //                  }).Concat //Then get group times
        //                 (from u in db.s_user
        //                  join gr in db.c_group_relationship on u.user_id equals gr.user_id
        //                  join g in db.c_group on gr.group_id equals g.group_id
        //                  join gce in db.c_group_calendar_entry on g.group_id equals gce.group_id
        //                  join t in db.t_times on gce.time_id equals t.time_id
        //                  join d in db.t_days on t.day_id equals d.day_id
        //                  join hh in db.t_half_hours on t.half_hour_id_start equals hh.half_hour_id
        //                  join hh2 in db.t_half_hours on t.half_hour_id_end equals hh2.half_hour_id
        //                  where u.username == username
        //                  select new TimeModel
        //                  {
        //                      UserName = u.username,
        //                      Day = d.day_text,
        //                      TimeIdStart = t.half_hour_id_start,
        //                      TimeIdEnd = t.half_hour_id_end,
        //                      TimeStart = hh.half_hour_time,
        //                      TimeEnd = hh2.half_hour_time
        //                  });

        //    return result.ToList();
        //}

        // GET: api/Time?groupname={groupname}
        // this should only work if you are part of an authenticated group that they are in - i'll figure this out later
        public IEnumerable<WorkingTimeModel> Get(string groupname, string hashedpw)
        {
            // first, get a list of all of the user times that are associated with the group
            var user_times = from g in db.c_group
                             join gr in db.c_group_relationship on g.group_id equals gr.group_id
                             join u in db.s_user on gr.user_id equals u.user_id
                             join ut in db.t_user_time on u.user_id equals ut.user_id
                             select ut;

            //then we get a list of times
            var anonymised_times = from ut in user_times
                                   join d in db.t_days on ut.day_id equals d.day_id
                                   join hh in db.t_half_hours on ut.half_hour_id_start equals hh.half_hour_id
                                   join hh2 in db.t_half_hours on ut.half_hour_id_end equals hh2.half_hour_id
                                   select new WorkingTimeModel
                                   {
                                       day = d.day_id,
                                       half_hour_start = hh.half_hour_id,
                                       half_hour_end = hh2.half_hour_id
                                   };

            //eliminate duplicates
            var times = anonymised_times.Distinct();

            // then, we get an array of unique user times in 30-min blocks in order to create a generic output for our users.
            // first we need a cross join of all half hour times and days (probably very inneficient)

            var time_days = from d in db.t_days
                            from hh in db.t_half_hours
                            select new
                            {
                                day_id = d.day_id,
                                half_hour_id = hh.half_hour_id
                            };


            // get all of the single times that are included
            var single_times = from at in times
                               from t in time_days
                               where t.half_hour_id <= at.half_hour_end
                                     && t.half_hour_id >= at.half_hour_start
                                     && t.day_id == at.day
                               select new WorkingTimeModel
                               {
                                   day = t.day_id,
                                   half_hour_start = t.half_hour_id,
                                   half_hour_end = t.half_hour_id
                               };

            single_times = single_times.Distinct();

            // then, return
            var output = single_times.ToList();

            return output;

        }



        // POST: api/Time
        public void Post(/*[FromBody]string value*/ string username, int dayId, int startId, int endId)
        {
        }

        // PUT: api/Time/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Time/5
        public void Delete(int id)
        {
        }
    }
}