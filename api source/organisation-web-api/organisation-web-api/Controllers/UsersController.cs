using organisation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using organisation_web_api.Api_Models;

namespace organisation_web_api.Controllers
{
    public class UsersController : ApiController
    {

        private Organisation_model db = new Organisation_model();

        // GET: api/Users?searchterm={Searchterm}
        public IEnumerable<UserModel> Get(string searchterm)
        {
            if (searchterm.IsNullOrWhiteSpace())
            {
                var result = db.s_user.Select(s => new UserModel
                {
                    UserName = s.username
                })
                .ToList();

                return result;
            }
            else
            {
                var result = db.s_user.Where(s => s.username.Contains(searchterm))
                    .Select(s => new UserModel
                    {
                        UserName = s.username
                    })
                    .ToList();

                return result;
            }
        }

        // GET: api/Users?username={username}
        public UserModel Get(string username, string hashedpw)
        {
            var result = db.s_user.Where(s => s.username == username)
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
                output = result.First();
            }
            catch (Exception e)
            {
                output = new UserModel
                {
                    UserName = "Username does not exist"
                };
            }

            return output;
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
