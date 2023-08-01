using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Rose.Models
{
    [TableName("ms_pet")]
    [PrimaryKey("id")]
    public class PetModel
    {
        public int id { get; set; }
        public string idpemilik { get; set; }
        public string sex { get; set; }
        public string jenis { get; set; }
        public string warna { get; set; }
        public string pola { get; set; }
        public string idklasifikasi { get; set; }
        public int isdelete { get; set; }
        public string nama { get; set; }
    }
}
