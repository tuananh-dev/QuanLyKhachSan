using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models;

namespace QLKSProject.Business.QuanLy
{
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

        public List<Phong> LayDanhSachPhong()
        {
            //var phong = models.Phongs.Where(e => e.IsDelete == false).Select(e => e).ToList();
          
               
            //TimeSpan timenhan=  - time1970;
            //TimeSpan timetra = -time1970;
            List<Phong> dsphong = models.Phongs.Where(e => e.IsDelete == false).OrderBy(e => e.DatPhongThanhCong_IDPhongs).Select(e => e).ToList();
           
            foreach (var itemphong in dsphong)
            {
                List<DatPhongThanhCong> dsPhongDaDuocDatThanhCong = models.DatPhongThanhCongs.Where(s => s.IDPhong == itemphong.ID).Select(a => a).ToList();                
                foreach(var itemdatphong in dsPhongDaDuocDatThanhCong)
                {
                    var khachhang = models.KhachHangs.Where(b => b.ID == itemdatphong.IDKhachHang).Select(b => b).FirstOrDefault();
                    
                }

            }
            return dsphong;
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
        private bool CapNhatTrangThaiPhong(DateTime datenhan,DateTime datetra)
        {
            DateTime datenow = DateTime.Now;
            DateTime time1970 = new DateTime(1970, 1, 1);
           
            return true;
        }
        #endregion
    }
}