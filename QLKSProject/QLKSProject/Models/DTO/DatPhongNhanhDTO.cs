using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKSProject.Models.DTO
{
    public class DatPhongNhanhDTO
    {
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoNguoiLon { get; set; }
        public int SoTreEm { get; set; }
        public DateTime NgayNhanPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
    }
}