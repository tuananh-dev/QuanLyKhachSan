
using System;

namespace QLKSProject.Models.DTO
{
    public class LichSuDichVu
    {
        public int ID { get; set; }
        public int IDPhong { get; set; }
        public int IDDichVu { get; set; }
        public DateTime NgayGoiDichVu { get; set; }
        public string GhiChu { get; set; }
        public int IDKhachHang { get; set; }
    }
}