using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKSProject.Models.Entities
{
    public class UserMaster
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }
        [Required]
        [StringLength(500)]
        public string UserRoles { get; set; }
        [Required]
        [StringLength(100)]
        public string UserEmailID { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public int UserID { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Required]
        public string MaDoan { get; set; }
    }
}