using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cobom.Models
{
    public class newarchievement
    {
        public int id { get; set; }
        public string type { get; set; }
        public string unit { get; set; }
    }

    public class newarchievementDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public double amount { get; set; }
        
        public string date { get; set; }
        public int newarchievementid { get; set; }
        public virtual newarchievement newarchievement { get; set; }
    }
}