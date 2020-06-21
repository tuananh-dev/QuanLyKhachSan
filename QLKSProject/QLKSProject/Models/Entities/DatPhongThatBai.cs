using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QLKSProject.Models
{
    public class DatPhongThatBai
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int IDKhachHang { get; set; }

        [StringLength(300)]
        public string GhiChu { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }

    }
}