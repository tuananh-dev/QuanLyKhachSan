using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using QLKSProject.Models;

namespace QLKSProject.Business.QuanLy
{
    //TaiKhoan
    public class QuanLyBusiness : BaseBusiness
    {
        public List<TaiKhoan> LayDanhSachTaiKhoan()
        {
            var taikhoan = models.TaiKhoans.Where(e => e.IsDelete == false).Select(e => e).ToList();
            return taikhoan;
        }

        public bool ThemTaiKhoan(TaiKhoan taikhoan)
        {
            try
            {
                models.TaiKhoans.Add(taikhoan);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //PHONG
        public List<Phong> LayDanhSachPhong()
        {
            var phong = models.Phongs.Where(e => e.IsDelete == false).Select(e => e).ToList();
            return phong;
        }
        public bool ThemPhong(Phong phong)
        {
            try
            {
                models.Phongs.Add(phong);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        ////DichVu
        //public List<DichVu> LayDanhSachDichVu()
        //{
        //    var dichvu = models.DichVus.Where(e => e.IsDelete == false).Select(e => e).ToList();
        //    return dichvu;
        //}
        //public bool ThemDichVu(DichVu dichvu)
        //{
        //    try
        //    {
        //        models.DichVus.Add(dichvu);
        //        models.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}


        ////Tien Ich
        //public List<TienIch> LayDanhSachTienIch()
        //{
        //    var tienich = models.TienIches.Where(e => e.IsDelete == false).Select(e => e).ToList();
        //    return tienich;
        //}
        //public bool ThemTienIch(TienIch tienich)
        //{
        //    try
        //    {
        //        models.TienIches.Add(tienich);
        //        models.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}
    }
}