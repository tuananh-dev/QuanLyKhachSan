using System;

namespace QLKSProject.Models
{
	public class FileKhachHang : KhachHang
    {
        public string TenDoan { get; set; }
        public DateTime NgayGui { get; set; }
        public string TenTruongDoan { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianTra { get; set; }   
    }
}