using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal
{
    public class Resignation
    {
        public int ID { get; set; }
        public string DeptName { get; set; }
        public string DeptPosition { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ResignationDate { get; set; }
        public int ContactNumber { get; set; }
    }
}
