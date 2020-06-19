using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QLKSProject.Models.Entities;


namespace QLKSProject.Models
{
    public class DatPhongThanhCong
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime ThoiGianNhan { get; set; }

        [Required]
        public DateTime ThoiGianTra { get; set; }

        [Required]
        public bool IsDelete { get; set; }
   
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<Phong> Phongs { get; set; }
        public virtual ICollection<DanhSachFileGui> DanhSachFileGui { get; set; }

    }
}