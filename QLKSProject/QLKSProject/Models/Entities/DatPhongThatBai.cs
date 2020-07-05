using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QLKSProject.Models.Entities
{
    public class DatPhongThatBai
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string TenDoan { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDoan { get; set; }

        [StringLength(2000)]
        public string GhiChu { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [ForeignKey("MaDoan")]
        public virtual Doan Doan_MaDoan { get; set; }


    }
}