using System;

namespace QLKSProject.Models.DTO
{
    public class DoanDTO
    {
        public int ID { get; set; }
        public string MaDoan { get; set; }
        public string TenDoan { get; set; }
        public DateTime NgayGui { get; set; }
        public string TenTruongDoan { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public int TrangThaiDatPhong { get; set; }
        public bool IsDelete { get; set; }
        public bool TrangThaiXacNhan { get; set; }
    }
}