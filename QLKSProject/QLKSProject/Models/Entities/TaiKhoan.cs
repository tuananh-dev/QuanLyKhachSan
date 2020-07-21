
using System;
using System.ComponentModel.DataAnnotations;


namespace QLKSProject.Models.Entities
{
    public class TaiKhoan
    {
		internal object username;

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
        public string Mail { get; set; }

        [Required]
        [StringLength(6)]
        public string LoaiTaiKhoan { get; set; }

        [Required]
        public bool IsDelete { get; set; }

		internal static bool Any(Func<object, object> p)
		{
			throw new NotImplementedException();
		}
	}
}