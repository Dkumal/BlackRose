using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Rose.Models
{
    [TableName("ms_user")]
    [PrimaryKey("id")]
    public class UserModels
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname{ get; set; }
        public int roleid{ get; set; }
        public  int isdelete { get; set; }
    }
}
