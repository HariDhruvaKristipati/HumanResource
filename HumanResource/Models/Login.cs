using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Models
{
    public class Login
    {
        [Display(Name =" Enter User ID")]
       
        public int id { get; set; }

        [Display(Name = "Enter Password")]
        public string password { get; set; }

    }
}