using organisation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace organisation_web_api.Controllers
{
    public class DaysController : ApiController
    {

        private Organisation_model db = new Organisation_model();

        // GET: api/Days
        public IEnumerable<t_days> Get()
        {
            return db.t_days.Select( s => s )
                            .ToList();        
        }

        // GET: api/Days/5
        public IEnumerable<t_days> Get(int id)
        {
            return db.t_days.Where(s => s.day_id == id)
                            .Select(s => s)
                            .ToList();
        }

        // POST: api/Days
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Days/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Days/5
        public void Delete(int id)
        {
        }
    }
}
