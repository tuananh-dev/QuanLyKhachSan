using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models.DTO;

namespace QLKSProject.Business.QuanLy
{
    public class QuanLyBusiness : BaseBusiness
    {
        public List<TaiKhoan> LayDanhSachTaiKhoan()
        {
            var lstTaiKhoan = models.TaiKhoans.Where(e => e.IsDelete == false).Select(e => new TaiKhoan
            {
                ID = e.ID,
                TenTaiKhoan = e.TenTaiKhoan,
                MatKhau = e.MatKhau,
                HoVaTen = e.HoVaTen,
                SoDienThoai = e.SoDienThoai,
                Mail = e.Mail,
                LoaiTaiKhoan = e.LoaiTaiKhoan,
                IsDelete = e.IsDelete
            });
            return lstTaiKhoan.ToList();
        }

        public TaiKhoan LayTaiKhoan(int idTaiKhoan)
        {

            var taiKhoan = models.TaiKhoans.Where(e => e.ID == idTaiKhoan).Select(e => new TaiKhoan
            {
                ID = e.ID,
                TenTaiKhoan = e.TenTaiKhoan,
                MatKhau = e.MatKhau,
                HoVaTen = e.HoVaTen,
                SoDienThoai = e.SoDienThoai,
                Mail = e.Mail,
                LoaiTaiKhoan = e.LoaiTaiKhoan,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return taiKhoan;
        }
        /*
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
       public List<DichVu> LayDanhSachDichVu()
       {
           var dichvu = models.DichVus.Where(e => e.IsDelete == false).Select(e => e).ToList();
           return dichvu;
       }
       public bool ThemDichVu(DichVu dichvu)
       {
           try
           {
               models.DichVus.Add(dichvu);
               models.SaveChanges();
               return true;
           }
           catch (Exception)
           {
               return false;
           }
       }
       public List<TienIch> LayDanhSachTienIch()
       {
           var tienich = models.TienIches.Where(e => e.IsDelete == false).Select(e => e).ToList();
           return tienich;
       }
       public bool ThemTienIch(TienIch tienich)
       {
           try
           {
               models.TienIches.Add(tienich);
               models.SaveChanges();
               return true;
           }
           catch (Exception)
           {
               return false;
           }
       }

       #region Private Methods
       private void Test()
       {

       }

       #endregion*/
    }
}