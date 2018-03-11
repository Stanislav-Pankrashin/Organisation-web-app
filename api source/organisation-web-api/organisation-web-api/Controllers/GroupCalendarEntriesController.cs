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
    public class GroupCalendarEntriesController : ApiController
    {
        private organisation_model db = new organisation_model();

        // GET: api/GroupCalendarEntries
        public IQueryable<c_group_calendar_entry> Getc_group_calendar_entry()
        {
            return db.c_group_calendar_entry;
        }

        // GET: api/GroupCalendarEntries/5
        [ResponseType(typeof(c_group_calendar_entry))]
        public IHttpActionResult Getc_group_calendar_entry(int id)
        {
            c_group_calendar_entry c_group_calendar_entry = db.c_group_calendar_entry.Find(id);
            if (c_group_calendar_entry == null)
            {
                return NotFound();
            }

            return Ok(c_group_calendar_entry);
        }

        // PUT: api/GroupCalendarEntries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putc_group_calendar_entry(int id, c_group_calendar_entry c_group_calendar_entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != c_group_calendar_entry.calendar_id)
            {
                return BadRequest();
            }

            db.Entry(c_group_calendar_entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!c_group_calendar_entryExists(id))
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

        // POST: api/GroupCalendarEntries
        [ResponseType(typeof(c_group_calendar_entry))]
        public IHttpActionResult Postc_group_calendar_entry(c_group_calendar_entry c_group_calendar_entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.c_group_calendar_entry.Add(c_group_calendar_entry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = c_group_calendar_entry.calendar_id }, c_group_calendar_entry);
        }

        // DELETE: api/GroupCalendarEntries/5
        [ResponseType(typeof(c_group_calendar_entry))]
        public IHttpActionResult Deletec_group_calendar_entry(int id)
        {
            c_group_calendar_entry c_group_calendar_entry = db.c_group_calendar_entry.Find(id);
            if (c_group_calendar_entry == null)
            {
                return NotFound();
            }

            db.c_group_calendar_entry.Remove(c_group_calendar_entry);
            db.SaveChanges();

            return Ok(c_group_calendar_entry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool c_group_calendar_entryExists(int id)
        {
            return db.c_group_calendar_entry.Count(e => e.calendar_id == id) > 0;
        }
    }
}