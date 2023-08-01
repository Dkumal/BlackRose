using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Rose.Models
{
    [TableName("ms_class")]
    [PrimaryKey("id")]
    public class ClassificationModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int isdelete { get; set; }
    }
}
