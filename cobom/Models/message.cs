using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cobom.Models
{
    public class message
    {
        public int id { get; set; }
        public string title { get; set; }

    }
    public class messagedetail
    {
        public int id { get; set; }
       
        public string body { get; set; }
        public string title { get; set; }

        public string fa { get; set; }


    }
}