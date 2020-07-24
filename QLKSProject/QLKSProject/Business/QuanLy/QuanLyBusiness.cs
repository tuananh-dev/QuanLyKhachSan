﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using QLKSProject.Models.DTO;

namespace QLKSProject.Business.QuanLy
{
    public class QuanLyBusiness : BaseBusiness
    {
        DateTime ngayDauThang;
        DateTime ngayCuoiThang;
        #region TaiKhoan
        public List<TaiKhoanDTO> LayDanhSachTaiKhoan()
        {
            var lstTaiKhoan = models.TaiKhoans.Where(e => e.IsDelete == false && e.LoaiTaiKhoan == "NV").Select(e => new TaiKhoanDTO
            {
                ID = e.ID,
                TenTaiKhoan = e.TenTaiKhoan,
                MatKhau = e.MatKhau,
                HoVaTen = e.HoVaTen,
                SoDienThoai = e.SoDienThoai,
                Email = e.Email,
                LoaiTaiKhoan = e.LoaiTaiKhoan,
                IsDelete = e.IsDelete
            });
            return lstTaiKhoan.ToList();
        }
        public TaiKhoanDTO LayTaiKhoan(int idTaiKhoan)
        {

            var taiKhoan = models.TaiKhoans.Where(e => e.ID == idTaiKhoan).Select(e => new TaiKhoanDTO
            {
                ID = e.ID,
                TenTaiKhoan = e.TenTaiKhoan,
                MatKhau = e.MatKhau,
                HoVaTen = e.HoVaTen,
                SoDienThoai = e.SoDienThoai,
                Email = e.Email,
                LoaiTaiKhoan = e.LoaiTaiKhoan,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return taiKhoan;
        }
        public bool ThemTaiKhoan(TaiKhoanDTO taiKhoan)
        {

                Models.Entities.TaiKhoan tk = new Models.Entities.TaiKhoan();
                if (CheckTaiKhoan(taiKhoan.TenTaiKhoan))
                {     
                tk.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                tk.MatKhau = taiKhoan.MatKhau;
                tk.HoVaTen = taiKhoan.HoVaTen;
                tk.SoDienThoai = taiKhoan.SoDienThoai;
                tk.Email = taiKhoan.Email;
                tk.LoaiTaiKhoan = taiKhoan.LoaiTaiKhoan;
                tk.IsDelete = taiKhoan.IsDelete;
                models.TaiKhoans.Add(tk);
                models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }    
        }
        public bool CapNhatTaiKhoan(TaiKhoanDTO taiKhoan) {

            try
            {
                var tk = models.TaiKhoans.Where(s => s.ID == taiKhoan.ID).FirstOrDefault();
                tk.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                tk.HoVaTen = taiKhoan.HoVaTen;
                tk.SoDienThoai = taiKhoan.SoDienThoai;
                tk.Email = taiKhoan.Email;
                tk.LoaiTaiKhoan = taiKhoan.LoaiTaiKhoan;
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaTaiKhoan(int idTaiKhoan)
        {
            var taikhoan = models.TaiKhoans.Where(e => e.ID == idTaiKhoan).FirstOrDefault();
            if (taikhoan != null)
            {
                taikhoan.IsDelete = true;
                models.SaveChanges();
                return true;
            }else
                return false;
        }
        #endregion

        #region Phong
        public List<PhongDTO> LayDanhSachPhong()
        {
            var lstphong = models.Phongs.Where(e => e.IsDelete == false).Select(e => new PhongDTO
            {
                ID = e.ID,
                MaPhong = e.MaPhong,
                SoPhong = e.SoPhong,
                LoaiPhong = e.LoaiPhong,
                Gia = e.Gia,
                TrangThai = e.TrangThai,
                IsDelete = e.IsDelete
            });
            return lstphong.ToList();
        }
        public PhongDTO LayPhong(int idPhong)
        {
            var phong = models.Phongs.Where(e => e.ID == idPhong).Select(e => new PhongDTO
            {
                ID = e.ID,
                MaPhong = e.MaPhong,
                SoPhong = e.SoPhong,
                LoaiPhong = e.LoaiPhong,
                Gia = e.Gia,
                TrangThai = e.TrangThai,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return phong;
        }
        public bool ThemPhong(PhongDTO phong)
        {

            Models.Entities.Phong ph = new Models.Entities.Phong();
            if (CheckPhong(phong.SoPhong))
            {
                
                ph.MaPhong = phong.MaPhong;
                ph.SoPhong = phong.SoPhong;
                ph.LoaiPhong = phong.LoaiPhong;
                ph.Gia = phong.Gia;
                ph.TrangThai = phong.TrangThai;
                ph.IsDelete = phong.IsDelete;
                models.Phongs.Add(ph);
                models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public bool CapNhatPhong(PhongDTO phong)
        {
            try
            {
                var ph = models.Phongs.Where(s => s.ID == phong.ID).FirstOrDefault();
                ph.MaPhong = phong.MaPhong;
                ph.SoPhong = phong.SoPhong;
                ph.LoaiPhong = phong.LoaiPhong;
                ph.Gia = phong.Gia;
              
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaPhong(int idPhong)
        {
            var phong = models.Phongs.Where(e => e.ID == idPhong).FirstOrDefault();
            if (phong != null)
            {
                phong.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region DichVu
        public List<DichVuDTO> LayDanhSachDichVu()
        {
            var lstdichvu = models.DichVus.Where(e => e.IsDelete == false).Select(e => new DichVuDTO {
                ID = e.ID,
                TenDichVu = e.TenDichVu,
                Gia = e.Gia,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            });
            return lstdichvu.ToList();
        }
        public DichVuDTO LayDichVu(int idDichVu)
        {
            var dichvu = models.DichVus.Where(e => e.ID == idDichVu).Select(e => new DichVuDTO
            {
                ID = e.ID,
                TenDichVu = e.TenDichVu,
                Gia = e.Gia,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return dichvu;
        }
        public bool ThemDichVu(DichVuDTO dichVu)
        {
            Models.Entities.DichVu dv = new Models.Entities.DichVu();
            if (CheckDichVu(dichVu.TenDichVu)) {
                   
                    dv.TenDichVu = dichVu.TenDichVu;
                    dv.Gia = dichVu.Gia;
                    dv.IsDelete = dichVu.IsDelete;
                    dv.MoTa = dichVu.MoTa;
                    models.DichVus.Add(dv);
                    models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
            

        }
        public bool CapNhatDichVu(DichVuDTO dichVu)
        {
            try
            {
                var dv = models.DichVus.Where(s => s.ID == dichVu.ID).FirstOrDefault();
                dv.TenDichVu = dichVu.TenDichVu;
                dv.Gia = dichVu.Gia;
                dv.MoTa = dichVu.MoTa;
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaDichVu(int idDichVu)
        {
            var dichvu = models.DichVus.Where(e => e.ID == idDichVu).FirstOrDefault();
            if (dichvu != null)
            {
                dichvu.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region TienIch
        public List<TienIchDTO> LayDanhSachTienIch()
        {
            var tienich = models.TienIches.Where(e => e.IsDelete == false).Select(e => new TienIchDTO {
                ID = e.ID,
                TenTienIch = e.TenTienIch,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            });
            return tienich.ToList();
        }
        public TienIchDTO LayTienIch(int idtienich)
        {
            var tienich = models.TienIches.Where(e => e.ID == idtienich).Select(e => new TienIchDTO
            {
                ID = e.ID,
                TenTienIch = e.TenTienIch,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return tienich;
        }
        public bool ThemTienIch(TienIchDTO tienIch)
        {
           
                if (CheckTienIch(tienIch.TenTienIch))
                {
                    Models.Entities.TienIch tienich = new Models.Entities.TienIch();
                    tienich.TenTienIch = tienIch.TenTienIch;
                    tienich.MoTa = tienIch.MoTa;
                    tienich.IsDelete = tienIch.IsDelete;
                    models.TienIches.Add(tienich);
                    models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }           
        }
        public bool CapNhatTienIch(TienIchDTO tienIch)
        {
            try
            {
                var tienich = models.TienIches.Where(s => s.ID == tienIch.ID).FirstOrDefault();
                tienich.TenTienIch = tienIch.TenTienIch;
                tienich.MoTa = tienIch.MoTa;
               
                models.SaveChanges();
                return true;
            
           }catch (Exception)

            {
                return false;
            }
           }
        public bool XoaTienIch(int idTienIch)
        {
            var tienich = models.TienIches.Where(e => e.ID == idTienIch).FirstOrDefault();
            if (tienich != null)
            {
                tienich.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Thong Ke
     
        public bool XuatThongKeTheoThang(int idkhachHang , int idPhong)
        {
            return false;
        }
      
        public bool XuatThongKeTheoQuy()
        {
            return false;
        }
        #endregion

        #region Private Methods
        private void LayNgayDauThangvaCuoiThang(int thang,int nam)
        {
            switch (thang)
            {
                case 1: ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 31);
                    break;
                case 2:ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 28);
                    break;
                case 3:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 31);
                    break;
                case 4:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 30);
                    break;
                case 5:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 31);
                    break;
                case 6:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 30);
                    break;
                case 7:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 31);
                    break;
                case 8:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 31);
                    break;
                case 9:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 30);
                    break;
                case 10:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 31);
                    break;
                case 11:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 30);
                    break;
                case 12:
                    ngayDauThang = new DateTime(nam, thang, 1);
                    ngayCuoiThang = new DateTime(nam, thang, 31);
                    break;
            }
            
        }
        private bool CheckTaiKhoan(String tenTaiKhoan)
        {
            bool b = true;
            List<TaiKhoanDTO> lstTaiKhoan = models.TaiKhoans.Select(s => new TaiKhoanDTO
            {
                TenTaiKhoan = s.TenTaiKhoan,
                MatKhau = s.MatKhau,
                HoVaTen = s.HoVaTen,
                SoDienThoai = s.SoDienThoai,
                Email = s.Email,
                LoaiTaiKhoan = s.LoaiTaiKhoan,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstTaiKhoan)
            {
                if (tenTaiKhoan.Equals(item.TenTaiKhoan)) 
                b = false;
                    
            }
            return  b;
        }
        private bool CheckPhong(String soPhong)
        {
            bool b = true;
            List<PhongDTO> lstPhong = models.Phongs.Select(s => new PhongDTO {
                MaPhong = s.MaPhong,
                SoPhong = s.SoPhong,
                LoaiPhong = s.LoaiPhong,
                Gia = s.Gia,
                TrangThai = s.TrangThai,
                IsDelete = s.IsDelete
            }).ToList();
            foreach(var item in lstPhong)
            {
                if (soPhong.Equals(item.SoPhong))
                    b = false;
            }
            return b;
        }
        private bool CheckDichVu(String tenDichVu)
        {
            bool b = true;
            List<DichVuDTO> lstDichVu = models.DichVus.Select(s => new DichVuDTO
            {
                TenDichVu = s.TenDichVu,
                Gia = s.Gia,
                MoTa = s.MoTa,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstDichVu)
            {
                if (tenDichVu.Equals(item.TenDichVu))
                    b = false;
            }
            return b;
        }
        private bool CheckTienIch(String tenTienIch)
        {
            bool b = true;
            List<TienIchDTO> lstTienIch= models.TienIches.Select(s => new TienIchDTO
            {
                TenTienIch = s.TenTienIch,
                MoTa = s.MoTa,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstTienIch)
            {
                if (tenTienIch.Equals(item.TenTienIch))
                    b = false;
            }
            return b;
        }
        private bool ChonTuan(DateTime dateTime)
        {
            
            return false;
        }
        #endregion
    }
}