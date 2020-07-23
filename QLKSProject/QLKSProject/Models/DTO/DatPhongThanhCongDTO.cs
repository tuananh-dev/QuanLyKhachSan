using System;


namespace QLKSProject.Models.DTO
{
    public class DatPhongThanhCongDTO
    {
        public int ID { get; set; }
        public int IDKhachHang { get; set; }
        public int IDPhong { get; set; }
        public bool IsDelete { get; set; }
        public DateTime NgayTraPhongThucTe { get; set; }
        public bool TrangThaiXacNhan { get; set; }
    }
}