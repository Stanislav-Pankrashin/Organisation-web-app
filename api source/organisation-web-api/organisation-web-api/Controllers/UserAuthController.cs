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
    public class UserAuthController : ApiController
    {
        private Organisation_model db = new Organisation_model();

        // GET: api/UserAuth
        private IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserAuth?username = {username},hashedpw = {hashedpw}
        public UserModel Get(string username, string hashedpw)
        {
            var result = db.s_user.Where(s => s.username == username && s.password == hashedpw)
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
                    UserName = "Password or Username is incorrect"
                };
            }

            return output;
        }

        // POST: api/UserAuth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserAuth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserAuth/5
        public void Delete(int id)
        {
        }
    }
}
