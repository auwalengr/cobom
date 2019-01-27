using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace cobom.Models
{
    public class slide
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string imgurl { get; set; }
        public string url { get; set; }

    }
}