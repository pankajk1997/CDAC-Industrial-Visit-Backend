using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class cuser
    {
        public int id { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string email { get; set; }

        public string pass { get; set; }

        public string phone { get; set; }
    }
}