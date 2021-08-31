using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResource.Models
{
    public class Trainingclass
    {
        public int ID { get; set; }
        public string TrainingName { get; set; }
        public string TrainingStatus { get; set; }
        public int TrainingPeriod { get; set; }
        public int TrainingExp { get; set; }
        public int PrevEmpExp { get; set; }
    
}
}