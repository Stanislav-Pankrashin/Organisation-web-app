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
    public class DaysController : ApiController
    {
        private organisation_model db = new organisation_model();

        // GET: api/Days
        public IQueryable<t_days> Gett_days()
        {
            return db.t_days;
        }

        // GET: api/Days/5
        [ResponseType(typeof(t_days))]
        public IHttpActionResult Gett_days(int id)
        {
            t_days t_days = db.t_days.Find(id);
            if (t_days == null)
            {
                return NotFound();
            }

            return Ok(t_days);
        }

        // PUT: api/Days/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_days(int id, t_days t_days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_days.day_id)
            {
                return BadRequest();
            }

            db.Entry(t_days).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_daysExists(id))
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

        // POST: api/Days
        [ResponseType(typeof(t_days))]
        public IHttpActionResult Postt_days(t_days t_days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_days.Add(t_days);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_days.day_id }, t_days);
        }

        // DELETE: api/Days/5
        [ResponseType(typeof(t_days))]
        public IHttpActionResult Deletet_days(int id)
        {
            t_days t_days = db.t_days.Find(id);
            if (t_days == null)
            {
                return NotFound();
            }

            db.t_days.Remove(t_days);
            db.SaveChanges();

            return Ok(t_days);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_daysExists(int id)
        {
            return db.t_days.Count(e => e.day_id == id) > 0;
        }
    }
}