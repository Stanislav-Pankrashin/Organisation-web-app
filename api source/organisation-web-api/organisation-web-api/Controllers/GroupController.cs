using organisation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace organisation_web_api.Controllers
{
    public class GroupController : ApiController
    {

        private Organisation_model db = new Organisation_model();

        // GET: api/Group
        //this shouldn't be public
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Group/5
        public IEnumerable<string> Get(string groupname)
        {
            var result = db.c_group.Where( s=> s.group_name == groupname)
                                   .Select(s => new string[] {s.group_name, s.group_desc});

            if ( result == null)
            {
                return new string[] { "invalid_group", "groupname invalid" }.ToList();
            }
            else
            {
                return result;
            }
        }

        // POST: api/Group
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
        }
    }
}
