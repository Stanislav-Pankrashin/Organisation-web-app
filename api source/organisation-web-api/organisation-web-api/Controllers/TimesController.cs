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
    public class TimesController : ApiController
    {
        private organisation_model db = new organisation_model();

        // GET: api/Times
        public IQueryable<t_times> Gett_times()
        {
            return db.t_times;
        }

        // GET: api/Times/5
        [ResponseType(typeof(t_times))]
        public IHttpActionResult Gett_times(int id)
        {
            t_times t_times = db.t_times.Find(id);
            if (t_times == null)
            {
                return NotFound();
            }

            return Ok(t_times);
        }

        // PUT: api/Times/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_times(int id, t_times t_times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_times.time_id)
            {
                return BadRequest();
            }

            db.Entry(t_times).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_timesExists(id))
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

        // POST: api/Times
        [ResponseType(typeof(t_times))]
        public IHttpActionResult Postt_times(t_times t_times)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_times.Add(t_times);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_times.time_id }, t_times);
        }

        // DELETE: api/Times/5
        [ResponseType(typeof(t_times))]
        public IHttpActionResult Deletet_times(int id)
        {
            t_times t_times = db.t_times.Find(id);
            if (t_times == null)
            {
                return NotFound();
            }

            db.t_times.Remove(t_times);
            db.SaveChanges();

            return Ok(t_times);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_timesExists(int id)
        {
            return db.t_times.Count(e => e.time_id == id) > 0;
        }
    }
}