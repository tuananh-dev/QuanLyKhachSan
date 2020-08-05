
using System;

namespace QLKSProject.Models.DTO
{
    public class LichSuDichVuDTO
    {
        public int ID { get; set; }
        public int IDPhong { get; set; }
        public string SoPhong { get; set; }
        public int IDDichVu { get; set; }
        public string TenDichVu { get; set; }
        public DateTime NgayGoiDichVu { get; set; }
        public string GhiChu { get; set; }
        public bool IsDelete { get; set; }
        public int IDKhachHang { get; set; }
        public string HoVaTenKhachHang { get; set; }
    }
}