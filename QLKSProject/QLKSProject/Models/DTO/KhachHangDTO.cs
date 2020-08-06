using System;


namespace QLKSProject.Models.DTO
{
    public class KhachHangDTO
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int Nhom { get; set; }
        public string NguoiDaiDienCuaTreEm { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public string MaDoan { get; set; }
        public bool GioiTinh { get; set; }
        public bool LoaiKhachHang { get; set; }
        public bool TruongDoan { get; set; }
        public bool IsDelete { get; set; }
        public int TrangThaiDatPhong { get; set; }
        public int IDPhong { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThaiXacNhan { get; set; }
        public string Sophong { get; set; }
    }
}