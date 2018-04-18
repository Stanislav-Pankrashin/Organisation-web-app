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


        public IEnumerable<UserModel> get(string groupname, string hashedpw)
        {
        }


        // POST: api/Group
        // this adds a user to a group
        public string Post(string username, string userpass, string groupname, string hashedpw)
        {
            // first check to see if a user has the correct pw
            var group = db.c_group.Where(s => s.group_name == groupname && s.group_password == hashedpw)
                .Select(s => s)
                .ToList();


            c_group target_group;
            try
            {
                target_group = group.First();

            }
            catch (Exception e)
            {
                return "group name or password incorrect";
            }

            // then check to see if the user credentials are correct

            var user = db.s_user.Where(s => s.username == username && s.password == userpass)
                .Select(s => s);

            s_user user_output;
            try
            {
                user_output = user.First();
            }
            catch (Exception e)
            {
                return "username or password incorrect";
            }

            // then, add the relationship

            var new_rel = new c_group_relationship
            {
                user_id = user_output.user_id,
                group_id = target_group.group_id,
                insert_user = username,
                insert_process = "ADDGRPREL",
                insert_datetime = DateTime.Now,
                update_user = null,
                update_process = null,
                update_datetime = null

            };

            db.c_group_relationship.Add(new_rel);

            db.SaveChanges();

            return "success";

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
