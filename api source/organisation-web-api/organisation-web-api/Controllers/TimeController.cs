using System;
using System.Collections.Generic;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Time?username={username}
        // this should only work if you are part of an authenticated group that they are in
        public IEnumerable<TimeModel> Get(string username)
        {
            var result = from u in db.s_user
                         join gr in db.c_group_relationship on u.user_id equals gr.user_id
                         join g in db.c_group on gr.group_id equals g.group_id
                         join uce in db.c_user_calendar_entry on u.user_id equals uce.user_id
                         join gce in db.c_group_calendar_entry on g.group_id equals gce.group_id
                         join t in db.t_times on new
                         {
                             JoinProperty1 = uce.time_id,
                             JoinProperty2 = gce.time_id
                         }
                             equals
                             new
                             {
                                 JoinProperty1 = t.time_id,
                                 JoinProperty2 = t.time_id
                             }
                         join d in db.t_days on t.day_id equals d.day_id
                         where u.username == username
                         select new TimeModel
                         {
                             UserName = u.username,
                             Day = d.day_text,
                             TimeIdStart = t.half_hour_id_start,
                             TimeIdEnd = t.half_hour_id_end
                         };

            return result.ToList();
        }

        // POST: api/Time
        public void Post([FromBody]string value)
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
