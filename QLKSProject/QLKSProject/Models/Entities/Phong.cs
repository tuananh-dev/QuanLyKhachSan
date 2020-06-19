using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models
{
    public class Phong
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        public string SoPhong { get; set; }

        [Required]
        [StringLength(10)]
        public string LoaiPhong { get; set; }    

        [Required]
        public int Gia { get; set; }

        [Required]
        public bool TrangThai { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public virtual PhongSuDungDichVu PhongSuDungDichVu { get; set; }


    }
}