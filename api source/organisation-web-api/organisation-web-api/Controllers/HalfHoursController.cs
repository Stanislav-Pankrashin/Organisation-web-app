﻿using organisation_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace organisation_web_api.Controllers
{
    public class HalfHoursController : ApiController
    {
        private Organisation_model db = new Organisation_model();

        // GET: api/HalfHours
        public IEnumerable<t_half_hours> Get()
        {
            return db.t_half_hours.Select(s => s)
                                  .ToList();
        }

        // GET: api/HalfHours/5
        public IEnumerable<t_half_hours> Get(int id)
        {
            return db.t_half_hours.Where(s => s.half_hour_id == id)
                                  .Select(s => s)
                                  .ToList();
        }

        // POST: api/HalfHours
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HalfHours/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HalfHours/5
        public void Delete(int id)
        {
        }
    }
}
