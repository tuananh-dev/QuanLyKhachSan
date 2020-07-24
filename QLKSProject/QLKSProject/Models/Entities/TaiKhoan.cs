
using System.ComponentModel.DataAnnotations;


namespace QLKSProject.Models.Entities
{
    public class TaiKhoan
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [Required]
        [StringLength(8)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string HoVaTen { get; set; }

        [Required]
        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(6)]
        public string LoaiTaiKhoan { get; set; }

        [Required]
        public bool IsDelete { get; set; }

    }
}