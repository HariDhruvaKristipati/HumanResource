using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResource.Models
{
    public class EmpDetails
    {
        public decimal Employee_id { get; set; }

        public string Employee_status { get; set; }
        public string Employee_Name { get; set; }
        public string Address { get; set; }
        public decimal Phone_number { get; set; }
        public int Age { get; set; }
        public string Supervisior_Name { get; set; }
        public string Department { get; set; }


    }
}