using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResource.Models
{
    public class Resignationclass
    {
        public int ID { get; set; }
        public string DeptName { get; set; }
        public string DeptPosition { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ResignationDate { get; set; }
        public int ContactNumber { get; set; }
    }
}