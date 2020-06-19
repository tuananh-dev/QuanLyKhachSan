using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models.Entities
{
    public class DanhSachFileGui
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDanhSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTruongDoan { get; set; }

        [Required]
        public DateTime NgayGui { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDoan { get; set; }

        public virtual DatPhongThanhCong DatPhongThanhCong { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

    }
}