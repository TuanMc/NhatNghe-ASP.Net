using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCodeFirst.Models
{
    [Table("KhoaHoc")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("MaKH")]
        public int Id { get; set; }
        [Column("TenKH")]
        public String Name { get; set; }
        [Column("HocPhi")]
        public double Tuition { get; set; }

    }
}