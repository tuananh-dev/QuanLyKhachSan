using QLKSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKSProject.Models
{
    public class FileKhachHang 
    {
        public string TenDoan { get; set; }
        public DateTime NgayGui { get; set; }
        public string TenTruongDoan { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public int ID { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Nhom { get; set; }
        public string NguoiDaiDienCuaTreEm { get; set; }
        public string MaDoan { get; set; }
        public bool GioiTinh { get; set; }
        public bool LoaiKhachHang { get; set; }
        public bool TruongDoan { get; set; }

    }
}