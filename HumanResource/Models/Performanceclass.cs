using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResource.Models
{
    public class Performanceclass
    {
        public int ID { get; set; }
        public string EmpName { get; set; }
        public string Division { get; set; }
        public string WorkGroup { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string Evaluator { get; set; }
        public int EvaluationPeriod { get; set; }
        public DateTime SickLeave { get; set; }
        public DateTime Vacation { get; set; }
        public DateTime Holiday { get; set; }
    }
}