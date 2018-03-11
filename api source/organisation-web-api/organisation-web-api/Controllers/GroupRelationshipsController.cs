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
    public class GroupRelationshipsController : ApiController
    {
        private organisation_model db = new organisation_model();

        // GET: api/GroupRelationships
        public IQueryable<c_group_relationship> Getc_group_relationship()
        {
            return db.c_group_relationship;
        }

        // GET: api/GroupRelationships/5
        [ResponseType(typeof(c_group_relationship))]
        public IHttpActionResult Getc_group_relationship(int id)
        {
            c_group_relationship c_group_relationship = db.c_group_relationship.Find(id);
            if (c_group_relationship == null)
            {
                return NotFound();
            }

            return Ok(c_group_relationship);
        }

        // PUT: api/GroupRelationships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putc_group_relationship(int id, c_group_relationship c_group_relationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != c_group_relationship.relationship_id)
            {
                return BadRequest();
            }

            db.Entry(c_group_relationship).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!c_group_relationshipExists(id))
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

        // POST: api/GroupRelationships
        [ResponseType(typeof(c_group_relationship))]
        public IHttpActionResult Postc_group_relationship(c_group_relationship c_group_relationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.c_group_relationship.Add(c_group_relationship);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = c_group_relationship.relationship_id }, c_group_relationship);
        }

        // DELETE: api/GroupRelationships/5
        [ResponseType(typeof(c_group_relationship))]
        public IHttpActionResult Deletec_group_relationship(int id)
        {
            c_group_relationship c_group_relationship = db.c_group_relationship.Find(id);
            if (c_group_relationship == null)
            {
                return NotFound();
            }

            db.c_group_relationship.Remove(c_group_relationship);
            db.SaveChanges();

            return Ok(c_group_relationship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool c_group_relationshipExists(int id)
        {
            return db.c_group_relationship.Count(e => e.relationship_id == id) > 0;
        }
    }
}