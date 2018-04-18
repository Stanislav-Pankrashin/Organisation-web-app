using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace organisation_web_api.Controllers
{
    public class WorkingTimeModel
    {
        public string day { get; set; }
        public string half_hour_start { get; set; }
        public string half_hour_end { get; set; }
    }
}