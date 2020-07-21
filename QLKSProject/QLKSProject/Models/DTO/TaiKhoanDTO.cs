

namespace QLKSProject.Models.DTO
{
    public class TaiKhoanDTO
    {
        public int ID { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Mail { get; set; }
        public string LoaiTaiKhoan { get; set; }
        public bool IsDelete { get; set; }
    }
}