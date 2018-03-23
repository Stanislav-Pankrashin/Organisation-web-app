using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace organisation_web_api.Api_Models
{
    public class TimeModel
    {
        public string UserName { get; set; }
        public string Day { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public int? TimeIdStart { get; set; }
        public int? TimeIdEnd { get; set; }
    }
}