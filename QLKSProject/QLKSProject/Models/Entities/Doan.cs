using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models.Entities
{
    public class Doan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Required]
        [StringLength(50)]
        public string MaDoan { get; set; }

        [Required]
        [StringLength(200)]
        public string TenDoan { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime NgayGui { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTruongDoan { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ThoiGianNhan { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ThoiGianTra { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        public int TrangThaiDatPhong { get; set; }

        [Required]
        public bool TrangThaiXacNhan { get; set; }

        public virtual ICollection<KhachHang> KhachHang_MaDoans { get; set; }

    }
}