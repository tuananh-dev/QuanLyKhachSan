using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models;


namespace QLKSProject.Business.Home
{
    public class HomeBusiness : BaseBusiness
    {

        public bool LuuDuLieuXuongCSDL(KhachHang KhachHang)
        {
            
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
        }

    }
}