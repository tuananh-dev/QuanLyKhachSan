using QLKSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKSProject.Business
{
    public class UserMasterRepository : BaseBusiness
    {

        public UserMaster ValidateUser(string username, string password)
        {
            var account = models.UserMasters.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);

            return account;
        }

    }
}