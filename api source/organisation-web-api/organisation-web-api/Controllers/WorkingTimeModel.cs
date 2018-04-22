using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace organisation_web_api.Controllers
{
    public class WorkingTimeModel
    {
        public int day { get; set; }
        public int half_hour_start { get; set; }
        public int half_hour_end { get; set; }
    }
}