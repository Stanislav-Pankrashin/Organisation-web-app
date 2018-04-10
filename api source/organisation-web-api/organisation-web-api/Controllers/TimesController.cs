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
        public IEnumerable<TimeModel> Get(string username)
        {
            //I know that using two queries isn't the best idea, but the only other alternative would have been to pull the entire times table, this would impact scaling
            var result = (from u in db.s_user //get all personal times first
                          join gr in db.c_group_relationship on u.user_id equals gr.user_id
                          join g in db.c_group on gr.group_id equals g.group_id
                          join uce in db.c_user_calendar_entry on u.user_id equals uce.user_id
                          join t in db.t_times on uce.time_id equals t.time_id
                          join d in db.t_days on t.day_id equals d.day_id
                          join hh in db.t_half_hours on t.half_hour_id_start equals hh.half_hour_id
                          join hh2 in db.t_half_hours on t.half_hour_id_end equals hh2.half_hour_id
                          where u.username == username
                          select new TimeModel
                          {
                              UserName = u.username,
                              Day = d.day_text,
                              TimeIdStart = t.half_hour_id_start,
                              TimeIdEnd = t.half_hour_id_end,
                              TimeStart = hh.half_hour_time,
                              TimeEnd = hh2.half_hour_time
                          }).Concat //Then get group times
                         (from u in db.s_user
                          join gr in db.c_group_relationship on u.user_id equals gr.user_id
                          join g in db.c_group on gr.group_id equals g.group_id
                          join gce in db.c_group_calendar_entry on g.group_id equals gce.group_id
                          join t in db.t_times on gce.time_id equals t.time_id
                          join d in db.t_days on t.day_id equals d.day_id
                          join hh in db.t_half_hours on t.half_hour_id_start equals hh.half_hour_id
                          join hh2 in db.t_half_hours on t.half_hour_id_end equals hh2.half_hour_id
                          where u.username == username
                          select new TimeModel
                          {
                              UserName = u.username,
                              Day = d.day_text,
                              TimeIdStart = t.half_hour_id_start,
                              TimeIdEnd = t.half_hour_id_end,
                              TimeStart = hh.half_hour_time,
                              TimeEnd = hh2.half_hour_time
                          });

            return result.ToList();
        }

        // GET: api/Time?groupname={groupname}
        // this should only work if you are part of an authenticated group that they are in - i'll figure this out later
        public IEnumerable<TimeModel> Get(string groupname, string hashedpw)
        {
            var result = from g in db.c_group
                         join gce in db.c_group_calendar_entry on g.group_id equals gce.group_id
                         join t in db.t_times on gce.time_id equals t.time_id
                         join d in db.t_days on t.day_id equals d.day_id
                         join hh in db.t_half_hours on t.half_hour_id_start equals hh.half_hour_id
                         join hh2 in db.t_half_hours on t.half_hour_id_end equals hh2.half_hour_id
                         where g.group_name == groupname &&
                               g.group_password == hashedpw
                         select new TimeModel
                         {
                             UserName = g.group_name,
                             Day = d.day_text,
                             TimeIdStart = t.half_hour_id_start,
                             TimeIdEnd = t.half_hour_id_end,
                             TimeStart = hh.half_hour_time,
                             TimeEnd = hh2.half_hour_time
                         };

            return result.ToList();
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