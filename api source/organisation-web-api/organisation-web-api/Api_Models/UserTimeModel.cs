using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace organisation_web_api.Api_Models
{
    public class UserTimeModel
    {
        public string Username { get; set; }
        public string DayText { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}