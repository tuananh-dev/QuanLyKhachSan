using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models
{
    public class PhongSuDungDichVu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int IDPhong { get; set; }

        [Required]
        public int IDDichVu { get; set; }

        [Required]
        public DateTime NgayGoiDichVu { get; set; }

        [Required]
        public int IDKhachHang { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<DichVu> DichVus { get; set; }

    }
}