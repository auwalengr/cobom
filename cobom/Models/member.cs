using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cobom.Models
{
    public class member
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        [Display(Name ="Other Name")]
        [Required(ErrorMessage = "Other name is required")]
        public string otherName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Local Government Area is required")]
        [Display(Name = "Local Government Area")]
        public string lga { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
    }
}