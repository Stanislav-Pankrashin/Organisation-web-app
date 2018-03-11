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
    public class GroupsController : ApiController
    {
        private organisation_model db = new organisation_model();

        // GET: api/Groups
        public IQueryable<c_group> Getc_group()
        {
            return db.c_group;
        }

        // GET: api/Groups/5
        [ResponseType(typeof(c_group))]
        public IHttpActionResult Getc_group(int id)
        {
            c_group c_group = db.c_group.Find(id);
            if (c_group == null)
            {
                return NotFound();
            }

            return Ok(c_group);
        }

        // PUT: api/Groups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putc_group(int id, c_group c_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != c_group.group_id)
            {
                return BadRequest();
            }

            db.Entry(c_group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!c_groupExists(id))
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

        // POST: api/Groups
        [ResponseType(typeof(c_group))]
        public IHttpActionResult Postc_group(c_group c_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.c_group.Add(c_group);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = c_group.group_id }, c_group);
        }

        // DELETE: api/Groups/5
        [ResponseType(typeof(c_group))]
        public IHttpActionResult Deletec_group(int id)
        {
            c_group c_group = db.c_group.Find(id);
            if (c_group == null)
            {
                return NotFound();
            }

            db.c_group.Remove(c_group);
            db.SaveChanges();

            return Ok(c_group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool c_groupExists(int id)
        {
            return db.c_group.Count(e => e.group_id == id) > 0;
        }
    }
}