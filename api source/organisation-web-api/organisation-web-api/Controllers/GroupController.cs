using organisation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public IEnumerable<c_group> Get()
        {
            return db.c_group.Select(s => s).ToList();
        }

        // GET: api/Group/5
        public IQueryable<dynamic> Get(string groupname)
        {
            var result = db.c_group.Where( s=> s.group_name == groupname)
                                   .Select(s => {
                                       var model = new Dictionary<string, string>();
                                       model.Add("GroupName", s.group_name);
                                       model.Add("GroupDesc", s.group_desc);
                                       return model;
                                       });
            return result;
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
