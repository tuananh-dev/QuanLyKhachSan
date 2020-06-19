using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models;

namespace QLKSProject.Business.Home
{
    public class HomeBusiness : BaseBusiness
    {

        public bool LuuDuLieuXuongCSDL(KhachHang dsKhachHang)
        {
            try
            {

                models.KhachHangs.Remove(dsKhachHang);
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