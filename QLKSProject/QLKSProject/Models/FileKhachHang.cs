using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKSProject.Models
{
    public class FileKhachHang : KhachHang
    {
        public string TenDoan { get; set; }
        public DateTime NgayGui { get; set; }
        public string MaDoan { get; set; }
        public string TenTruongDoan { get; set; }
    }
}