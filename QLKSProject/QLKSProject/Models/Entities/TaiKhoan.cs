using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models
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
        public string Mail { get; set; }

        [Required]
        [StringLength(6)]
        public string LoaiTaiKhoan { get; set; }

        [Required]
        public bool IsDelete { get; set; }

    }
}