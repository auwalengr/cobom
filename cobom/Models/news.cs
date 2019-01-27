using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cobom.Models
{
    public class news
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime datetime { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Header Picture")]
        public string imgurl { get; set; }
        public int shares { get; set; }
        [Display(Name ="Category")]
        public int newscategoryid { get; set; }
       

    }

   public class newscategory
    {
        public int id { get; set; }
        public string category { get; set; }
        public int order { get; set; }
    }

    public class newsComment
    {
        public int id { get; set; }
        public int newsid { get; set; }
        public string user  { get; set; }
        public  string comment { get; set; }
        public DateTime date { get; set; }
    }
}