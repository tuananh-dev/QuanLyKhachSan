using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKSProject.Models.DTO
{
    public class UserMasterDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRoles { get; set; }
        public string UserEmailID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int UserID { get; set; }
        public string MaDoan { get; set; }
        public bool IsDelete { get; set; }
    }
}