using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Rose.Models
{
    
    public class ExaminationFormLoadModel
    {
        public int idhewan { get; set; }
        public int iddokter { get; set; }
        public DateTime examdate { get; set; }

        public int age { get; set; }
        public int weight { get; set; }
        public decimal temperature { get; set; }
        public int bodyscore { get; set; }
        public string petdiet { get; set; }

        public int eating { get; set; }
        public int drinking { get; set; }
        public int coughing { get; set; }
        public int sneezing { get; set; }
        public int diarhea { get; set; }
        
        public  string healthconcern { get; set; }
        public string physicalexam { get; set; }
        public string need { get; set; }
        public string service { get; set; }
        public string lastmedication { get; set; }
        public string therapy { get; set; }
        public string diagnose { get; set; }

        public PetModel datapet { get; set; }
        public ExamDataModel examdata { get; set; }

        public string namadokter { get; set; }
    }
}
