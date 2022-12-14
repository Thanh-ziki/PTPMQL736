using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PTPMQL.Models
{
    [Table("Meetings")]
    public class Meeting
    {
        [Key]
        public string IDNhanVien { get; set; }
        public string ChuDeHop { get; set; }
        public string MaChuyenBay { get; set; }
        public string DateTime { get; set; }
        public string NoiDungHop { get; set; }
    }
}
