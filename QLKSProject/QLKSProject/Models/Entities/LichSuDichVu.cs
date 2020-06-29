using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models
{
    public class LichSuDichVu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int IDPhong { get; set; }

        [Required]
        public int IDDichVu { get; set; }

        [Required]
        public DateTime NgayGoiDichVu { get; set; }

        public string GhiChu { get; set; }

        [Required]
        public int IDKhachHang { get; set; }

        [ForeignKey("IDPhong")]
        public virtual Phong Phong_IDPhong { get; set; }

        [ForeignKey("IDKhachHang")]
        public virtual KhachHang KhachHang_IDKhachHang { get; set; }

        [ForeignKey("IDDichVu")]
        public virtual DichVu DichVu_IDDichVu { get; set; }

    }
}