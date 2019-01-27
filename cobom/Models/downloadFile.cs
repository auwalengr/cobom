using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cobom.Models
{
    public class downloadFile
    {
        public int ID { get; set; }
        [DataType(DataType.Upload)]
        public string Name { get; set; }
        public string description { get; set; }
        public string ContentType { get; set; }

        public byte[] Data { get; set; }
        //public HttpPostedFileBase Files { get; set; }
    }
}