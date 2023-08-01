using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPoco;

namespace Black_Rose.Models
{
    [TableName("ms_patient")]
    [PrimaryKey("id")]
    public class PatientModel
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        public long ktp { get; set; }
        public int isdelete { get; set; }


    }
}
