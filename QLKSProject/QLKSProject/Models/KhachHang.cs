﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models
{
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string HoVaTen { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        [StringLength(50)]
        public string TruongDoan { get; set; }
      
        public virtual DatPhongThatBai DatPhongThatBai { get; set; }
        public virtual PhongSuDungDichVu PhongSuDungDichVu { get; set; }
        public virtual DatPhongThanhCong DatPhongThanhCong { get; set; }
    }
}