
namespace QLKSProject.Models.DTO
{
    public class PhongDTO
    {
        public int ID { get; set; }
        public string MaPhong { get; set; }
        public string SoPhong { get; set; }
        public int LoaiPhong { get; set; }    
        public int Gia { get; set; }
        public bool TrangThai { get; set; }
        public bool IsDelete { get; set; }
    }
}