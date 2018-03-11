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
    public class HalfHoursController : ApiController
    {
        private organisation_model db = new organisation_model();

        // GET: api/HalfHours
        public IQueryable<t_half_hours> Gett_half_hours()
        {
            return db.t_half_hours;
        }

        // GET: api/HalfHours/5
        [ResponseType(typeof(t_half_hours))]
        public IHttpActionResult Gett_half_hours(int id)
        {
            t_half_hours t_half_hours = db.t_half_hours.Find(id);
            if (t_half_hours == null)
            {
                return NotFound();
            }

            return Ok(t_half_hours);
        }

        // PUT: api/HalfHours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_half_hours(int id, t_half_hours t_half_hours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_half_hours.half_hour_id)
            {
                return BadRequest();
            }

            db.Entry(t_half_hours).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_half_hoursExists(id))
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

        // POST: api/HalfHours
        [ResponseType(typeof(t_half_hours))]
        public IHttpActionResult Postt_half_hours(t_half_hours t_half_hours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_half_hours.Add(t_half_hours);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_half_hours.half_hour_id }, t_half_hours);
        }

        // DELETE: api/HalfHours/5
        [ResponseType(typeof(t_half_hours))]
        public IHttpActionResult Deletet_half_hours(int id)
        {
            t_half_hours t_half_hours = db.t_half_hours.Find(id);
            if (t_half_hours == null)
            {
                return NotFound();
            }

            db.t_half_hours.Remove(t_half_hours);
            db.SaveChanges();

            return Ok(t_half_hours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_half_hoursExists(int id)
        {
            return db.t_half_hours.Count(e => e.half_hour_id == id) > 0;
        }
    }
}