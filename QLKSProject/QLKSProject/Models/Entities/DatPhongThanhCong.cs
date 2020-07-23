using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace QLKSProject.Models.Entities
{
    public class DatPhongThanhCong
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int IDKhachHang { get; set; }

        [Required]
        public int IDPhong { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        public bool TrangThaiXacNhan { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayTraPhongThucTe { get; set; }
        
        [ForeignKey("IDKhachHang")]
        public virtual KhachHang KhachHang_IDKhachHang { get; set; }

        [ForeignKey("IDPhong")]
        public virtual Phong Phong_IDPhong { get; set; }




    }
}