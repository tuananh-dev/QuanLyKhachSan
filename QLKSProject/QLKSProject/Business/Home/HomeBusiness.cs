using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models;
using QLKSProject.Models.Entities;

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

		internal List<Doan> LayDuLieuXuongCSDL(object fileKhachHang)
		{
			throw new NotImplementedException();
		}

		internal List<Doan> LayDanhSachDoan()
		{
			throw new NotImplementedException();
		}

		internal List<KhachHang> LayDanhSachKhachHang()
		{
			throw new NotImplementedException();
		}
	}
}