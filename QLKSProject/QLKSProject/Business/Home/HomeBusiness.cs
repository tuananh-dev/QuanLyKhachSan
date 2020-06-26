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

        public bool LuuDuLieuXuongCSDL(KhachHang KhachHang)
        {
<<<<<<< HEAD
            
            try
            {
                models.KhachHangs.Add(KhachHang);
                models.SaveChanges();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Loi lay du lieu DanhSachFileGui");
                return false;
            }
            return true;
=======
            try {
                models.KhachHangs.Add(dsKhachHang);
                models.SaveChanges();
                return true;
                
            }
            catch (Exception e)
            {
                return false;
            }
            
>>>>>>> origin/nhatnam
        }

    }
}