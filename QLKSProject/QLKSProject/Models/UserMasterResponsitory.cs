using QLKSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKSProject.Models
{
    public class UserMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        QLKSDbContext context = new QLKSDbContext();
        //This method is used to check and validate the user credentials
        public UserMaster ValidateUser(string username, string password)
        {
            var account = context.UserMasters.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
            return account;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}