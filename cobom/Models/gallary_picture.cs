using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cobom.Models
{
    public class gallary_picture
    {
        public int id { get; set; }
        public string details { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
       
        public string imgurl { get; set; }
    }
}