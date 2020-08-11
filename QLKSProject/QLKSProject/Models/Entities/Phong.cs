using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models.Entities
{
    public class Phong
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(4)]
        public string SoPhong { get; set; }

        [Required]
        public int LoaiPhong { get; set; }    

        [Required]
        public int Gia { get; set; }

        [Required]
        public int TrangThai { get; set; }

        [Required]
        public bool IsDelete { get; set; }
        
        public virtual ICollection<LichSuDichVu> LichSuDichVu_IDPhongs { get; set; }


    }
}