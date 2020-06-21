﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models
{
    public class DichVu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDichVu { get; set; }

        [Required]
        public int Gia { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public PhongSuDungDichVu PhongSuDungDichVu { get; set; }
    }
}