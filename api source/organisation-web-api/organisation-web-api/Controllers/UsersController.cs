using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using organisation_web_api.Models;

namespace organisation_web_api.Controllers
{
    public class UsersController : ApiController
    {
        private organisation_model db = new organisation_model();

        // GET: api/Users
        public IQueryable<s_user> Gets_user()
        {
            // var results = db.s_user.Select(s => new { s.username }) as IQueryable<s_user>;
            // return results;
            return db.s_user;
        }

        // GET: api/Users/5
        [ResponseType(typeof(s_user))]
        public IHttpActionResult Gets_user(int id)
        {
            s_user s_user = db.s_user.Find(id);
            if (s_user == null)
            {
                return NotFound();
            }

            return Ok(s_user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puts_user(int id, s_user s_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != s_user.user_id)
            {
                return BadRequest();
            }

            db.Entry(s_user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!s_userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(s_user))]
        public IHttpActionResult Posts_user(s_user s_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.s_user.Add(s_user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = s_user.user_id }, s_user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(s_user))]
        public IHttpActionResult Deletes_user(int id)
        {
            s_user s_user = db.s_user.Find(id);
            if (s_user == null)
            {
                return NotFound();
            }

            db.s_user.Remove(s_user);
            db.SaveChanges();

            return Ok(s_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool s_userExists(int id)
        {
            return db.s_user.Count(e => e.user_id == id) > 0;
        }
    }
}