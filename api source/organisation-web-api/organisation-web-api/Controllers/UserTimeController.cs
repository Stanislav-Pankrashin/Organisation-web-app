using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using organisation_web_api.Api_Models;
using organisation_web_api.Models;

namespace organisation_web_api.Controllers
{
    public class UserTimeController : ApiController
    {
        private Organisation_model db = new Organisation_model();

        // GET: api/UserTime
        // this should probably be private
        public IEnumerable<t_user_time> Get()
        {
            var result = db.t_user_time.Select(s => s)
                                                 .ToList();

            return result;

        }

        // GET: api/UserTime/5
        public IEnumerable<UserTimeModel> Get(string username, string hashedPw)
        {
            // first check to see if the username and credentials are valid

            var user = db.s_user.Where(s => s.username == username && s.password == hashedPw)
                .ToList()
                .Select(s =>
                {
                    var model = new UserModel
                    {
                        UserName = s.username
                    };
                    return model;
                });

            UserModel output;
            try
            {
                output = user.First();
            }
            catch (Exception e)
            {
                output = new UserModel
                {
                    UserName = "Password or Username is incorrect"
                };
            }

            if (output.UserName.Equals("Password or Username is incorrect"))
            {
                return new List<UserTimeModel>();
            }


            // if the credentials are valid, we go on.

            int? userId = db.s_user.Where(s => s.username == output.UserName)
                .Select(s => s.user_id)
                .ToList()
                .First();

            var result = from u in db.s_user
                join ut in db.t_user_time on u.user_id equals ut.user_id
                join d in db.t_days on ut.day_id equals d.day_id
                join hh in db.t_half_hours on ut.half_hour_id_start equals hh.half_hour_id
                join hh2 in db.t_half_hours on ut.half_hour_id_end equals hh2.half_hour_id
                select new UserTimeModel
                {
                    Username = u.username,
                    DayText = d.day_text,
                    StartTime = hh.half_hour_time,
                    EndTime = hh2.half_hour_time

                };

            return result;
        }

        // POST: api/UserTime
        public void Post(string username, string hashedPw, string dayText, string startTime, string endTime)
        {
            // first check to see if the username and credentials are valid

            var user = db.s_user.Where(s => s.username == username && s.password == hashedPw)
                .ToList()
                .Select(s =>
                {
                    var model = new UserModel
                    {
                        UserName = s.username
                    };
                    return model;
                });

            UserModel output;
            try
            {
                output = user.First();
            }
            catch (Exception e)
            {
                output = new UserModel
                {
                    UserName = "Password or Username is incorrect"
                };
            }

            if (output.UserName.Equals("Password or Username is incorrect"))
            {
                return;
            }

            // if credentials are valid, then we get the user id and insert

            int? userId = db.s_user.Where(s => s.username == output.UserName)
                .Select(s => s.user_id)
                .ToList()
                .First();

            int? dayId = db.t_days.Where(s => s.day_text == dayText)
                .Select(s => s.day_id)
                .ToList()
                .First();

            int? startId = db.t_half_hours.Where(s => s.half_hour_time == startTime)
                .Select(s => s.half_hour_id)
                .ToList()
                .First();

            int? endId = db.t_half_hours.Where(s => s.half_hour_time == endTime)
                .Select(s => s.half_hour_id)
                .ToList()
                .First();

            // if any of these are null just return
            var error1 = dayId ?? -1;
            var error2 = startId ?? -1;
            var error3 = endId ?? -1;

            if (error1 == -1 ||
                error2 == -1 ||
                error3 == -1)
            {
                return;
            }

            var newTime = new t_user_time
            {
                user_id = userId,
                day_id = dayId,
                half_hour_id_start = startId,
                half_hour_id_end = endId,
                insert_user = username,
                insert_process = "add_time",
                insert_datetime = DateTime.Now
            };

            db.t_user_time.Add(newTime);

            db.SaveChangesAsync();

        }

        // PUT: api/UserTime/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserTime/5
        public void Delete(int id)
        {
        }
    }
}
