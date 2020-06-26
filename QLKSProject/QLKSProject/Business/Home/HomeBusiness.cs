using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using QLKSProject.Models;

namespace QLKSProject.Business.Home
{
    public class HomeBusiness : BaseBusiness
    {

        public bool LuuDuLieuXuongCSDL(KhachHang dsKhachHang)
        {
            try {
                models.KhachHangs.Add(dsKhachHang);
                models.SaveChanges();
                return true;
                
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}