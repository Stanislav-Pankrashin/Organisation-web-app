using organisation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace organisation_web_api.Controllers
{
    public class UsersController : ApiController
    {

        private Organisation_model db = new Organisation_model();

        // GET: api/Users
        // this probably shouldn't be public
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/username/pw
        public string Get(string username, string hashedpw)
        {
            var result = db.s_user.Where(s => s.username == username)
                                  .Where(s => s.password == hashedpw)
                                  .Select(s => s.username.ToString());

            if (result == null)
            {
                return "Username or password incorrect";
            }
            else
            {
                return result.ToList()[0]; // convert to a list, and then get the first element
            }
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
