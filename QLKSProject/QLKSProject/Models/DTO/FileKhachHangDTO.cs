using System;
using System.Collections.Generic;
using QLKSProject.Models.DTO;

namespace QLKSProject.Models.DTO
{
	public class FileKhachHangDTO

    {
        public string TenDoan { get; set; }
        public DateTime NgayGui { get; set; }
        public string HoTenTruongDoan { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianTra { get; set; }
        List<KhachHangDTO> KhachHangs { get; set; }
    }
}