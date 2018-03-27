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
    public class GroupAuthController : ApiController
    {
        private Organisation_model db = new Organisation_model();

        // GET: api/GroupAuth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GroupAuth/5
        public GroupModel Get(string groupname, string hashedpw)
        {
            var result = db.c_group.Where(s => s.group_name == groupname && s.group_password == hashedpw)
                .ToList()
                .Select(s =>
                {
                    var model = new GroupModel
                    {
                        GroupName = s.group_name,
                    };
                    return model;
                });

            GroupModel output;
            try
            {
                output = result.First();
            }
            catch (Exception e)
            {
                output = new GroupModel
                {
                    GroupName = "Password or Username is incorrect"
                };
            }

            return output;
        }

        // POST: api/GroupAuth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GroupAuth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GroupAuth/5
        public void Delete(int id)
        {
        }
    }
}
