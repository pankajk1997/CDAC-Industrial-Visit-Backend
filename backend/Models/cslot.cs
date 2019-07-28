using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class cslot
    {
        public int id { get; set; }

        public System.DateTime vdate { get; set; }

        public string stat { get; set; }

        public string feedback { get; set; }

        public string org { get; set; }

        public int uid { get; set; }
    }
}