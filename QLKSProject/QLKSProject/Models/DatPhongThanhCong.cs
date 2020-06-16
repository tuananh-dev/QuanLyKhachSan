using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QLKSProject.Models
{
    public class DatPhongThanhCong
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int IDPhong { get; set; }

        [Required]
        public DateTime ThoiGianNhan { get; set; }

        [Required]
        public DateTime ThoiGianTra { get; set; }

        [Required]
        public int IDKhachHang { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        public bool IsDelete { get; set; }
        
       
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}