using QLKSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace QLKSProject.Business.QuanLy
{
    public class QuanLyBusiness : BaseBusiness
    {
        public List<TaiKhoan>HienThiDanhSach()
        {
            var dstaikhoan = models.TaiKhoans.Where(e => e.IsDelete == false).Select(e =>e).ToList();
            return dstaikhoan;
        }
        public bool LuuTaiKhoanXuongCSDL(TaiKhoan dstaikhoan)
        {
            try
            {
                models.TaiKhoans.Add(dstaikhoan);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SuaTaiKhoan(TaiKhoan dstaikhoan)
        {
            var TaikhoanEdit = models.TaiKhoans.Where(e => e.ID == dstaikhoan.ID).FirstOrDefault();
            if(TaikhoanEdit != null) {
                models.TaiKhoans.Remove(TaikhoanEdit);
                models.TaiKhoans.Add(dstaikhoan);
                models.SaveChanges();
                return true;
            }
            return false;
        }
    
        public bool XoaTaiKhoan(int id)
        {
            var result = false;
            var TaikhoanEdit = models.TaiKhoans.Where(e => e.ID == id).FirstOrDefault();
            if(TaikhoanEdit != null)
            {
                models.TaiKhoans.Remove(TaikhoanEdit);
                models.SaveChanges();
                return true;
            }
            return result;
        }
        }
}