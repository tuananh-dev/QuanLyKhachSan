using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProjectTest.Models.Entities
{
    public class DichVu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDichVu { get; set; }

        [Required]
        [StringLength(2000)]
        public string MoTa { get; set; }

        [Required]
        public int Gia { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public virtual ICollection<LichSuDichVu> LichSuDichVu_IDDichVu { get; set; }
    }
}