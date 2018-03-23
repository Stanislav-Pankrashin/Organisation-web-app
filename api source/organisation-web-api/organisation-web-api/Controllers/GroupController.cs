using organisation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using organisation_web_api.Api_Models;

namespace organisation_web_api.Controllers
{
    public class GroupController : ApiController
    {

        private readonly Organisation_model db = new Organisation_model();

        // GET: api/Group
        public IEnumerable<GroupModel> Get()
        {
            return db.c_group.Select(s => new GroupModel
            {
                GroupName = s.group_name,
                GroupDesc = s.group_desc
            }).ToList();
        }

        // GET: api/Group?groupname = {groupname}
        public GroupModel Get(string groupname)
        {
            var result = db.c_group.Where(s => s.group_name == groupname)
                                   .ToList()
                                   .Select(s =>
                                   {
                                       var model = new GroupModel
                                       {
                                           GroupName = s.group_name,
                                           GroupDesc = s.group_desc
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
                    GroupName = "Invalid",
                    GroupDesc = "Invalid"
                };
            }

            return output;
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
