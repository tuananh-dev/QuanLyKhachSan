using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace QLKSProjectTest.Models.Entities
{
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string HoVaTen { get; set; }

        [Required]
        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        public int Nhom { get; set; }

        [StringLength(200)]
        public string NguoiDaiDienCuaTreEm { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ThoiGianNhan { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ThoiGianTra { get; set; }

        public string GhiChu { get; set; }

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
        
        [Required]
        public int TrangThaiDatPhong { get; set; }

        public int IDPhong { get; set; }

        [Required]
        public bool TrangThaiXacNhan { get; set; }

        [ForeignKey("MaDoan")]
        public virtual Doan Doan_MaDoan { get; set; }   

        public virtual ICollection<LichSuDichVu> LichSuDichVu_IDKhachHangs { get; set; }

    }
}