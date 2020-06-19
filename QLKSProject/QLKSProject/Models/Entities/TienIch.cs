using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKSProject.Models
{
    public class TienIch
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTienIch { get; set; }

        [Required]
        public string HinhAnh { get; set; }

    }
}