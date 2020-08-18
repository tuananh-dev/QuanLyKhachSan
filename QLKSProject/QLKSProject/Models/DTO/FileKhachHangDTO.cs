using System;
using System.Collections.Generic;
using QLKSProject.Models.DTO;

namespace QLKSProject.Models.DTO
{
	public class FileKhachHangDTO

    {
        public string TenDoan { get; set; }
        public string TenTruongDoan { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public string Files { get; set; }
    }
}