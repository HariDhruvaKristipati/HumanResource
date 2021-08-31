using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal
{
   public  class PayRoll
    {
        public int ID { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }

    }
}
