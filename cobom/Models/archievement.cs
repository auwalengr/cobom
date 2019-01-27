using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cobom.Models
{
    public class archievement
    {
        public int id { get; set; }
        public string type { get; set; }
        public string details { get; set; }
        public string location { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        public string imgurl { get; set; }

    }
}