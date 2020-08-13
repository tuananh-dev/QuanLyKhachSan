
using System.ComponentModel.DataAnnotations;

namespace QLKSProjectTest.Models.Entities
{
    public class TienIch
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTienIch { get; set; }

        [Required]
        public string MoTa { get; set; }
        [Required]
        public bool IsDelete { get; set; }
    }
}