using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QLKSProject.Models.Entities;



namespace QLKSProject.Models
{
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string HoVaTen { get; set; }

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
        [StringLength(50)]
        public string Nhom { get; set; }

        [Required]
        [StringLength(100)]
        public string NguoiDaiDienCuaTreEm { get; set; }

        [Required]
        public DateTime ThoiGianNhan { get; set; }

        [Required]
        public DateTime ThoiGianTra { get; set; }


        [Required]
        [StringLength(50)]
        public string MaDoan { get; set; }

        [Required]
        public bool GioiTinh { get; set; }

        [Required]
        public bool LoaiKhachHang { get; set; }

        [Required]
        public bool TruongDoan { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [ForeignKey("MaDoan")]
        public virtual Doan Doan_MaDoan { get; set; }

        public virtual ICollection<DatPhongThanhCong> DatPhongThanhCong_IDKhachHangs { get; set; }
        public virtual ICollection<LichSuDichVu> LichSuDichVu_IDKhachHangs { get; set; }

    }
}