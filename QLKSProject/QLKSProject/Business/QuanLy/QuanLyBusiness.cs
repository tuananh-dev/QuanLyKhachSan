﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using QLKSProject.Models.DTO;

namespace QLKSProject.Business.QuanLy
{
    public class QuanLyBusiness : BaseBusiness
    {
        //TAIKHOAN
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
        public bool ThemTaiKhoan(TaiKhoan taiKhoan)
        {
            try
            {
                if (CheckTaiKhoan(taiKhoan.TenTaiKhoan))
                {
                    Models.Entities.TaiKhoan tk = new Models.Entities.TaiKhoan();
                    tk.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                    tk.MatKhau = taiKhoan.MatKhau;
                    tk.HoVaTen = taiKhoan.HoVaTen;
                    tk.SoDienThoai = taiKhoan.SoDienThoai;
                    tk.Mail = taiKhoan.Mail;
                    tk.LoaiTaiKhoan = taiKhoan.LoaiTaiKhoan;
                    tk.IsDelete = taiKhoan.IsDelete;
                    models.TaiKhoans.Add(tk);
                    models.SaveChanges();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return CheckTaiKhoan(taiKhoan.TenTaiKhoan);
        }
        public bool CapNhatTaiKhoan(TaiKhoan taiKhoan) {

            try
            {
                var tk = models.TaiKhoans.Where(s => s.ID == taiKhoan.ID).FirstOrDefault();
                tk.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                tk.HoVaTen = taiKhoan.HoVaTen;
                tk.SoDienThoai = taiKhoan.SoDienThoai;
                tk.Mail = taiKhoan.Mail;
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
        //PHONG
        public List<Phong> LayDanhSachPhong()
        {
            var lstphong = models.Phongs.Where(e => e.IsDelete == false).Select(e => new Phong
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
        public Phong LayPhong(int idPhong)
        {
            var phong = models.Phongs.Where(e => e.ID == idPhong).Select(e => new Phong
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
        public bool ThemPhong(Phong phong)
        {
           
            try
            {
                if (CheckPhong(phong.SoPhong))
                {
                    Models.Entities.Phong ph = new Models.Entities.Phong();
                    ph.MaPhong = phong.MaPhong;
                    ph.SoPhong = phong.SoPhong;
                    ph.LoaiPhong = phong.LoaiPhong;
                    ph.Gia = phong.Gia;
                    ph.IsDelete = phong.IsDelete;

                    models.Phongs.Add(ph);
                    models.SaveChanges();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

            return CheckPhong(phong.SoPhong);
        }
        public bool CapNhatPhong(Phong phong)
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
        //DICHVU
        public List<DichVu> LayDanhSachDichVu()
        {
            var lstdichvu = models.DichVus.Where(e => e.IsDelete == false).Select(e => new DichVu {
                ID = e.ID,
                TenDichVu = e.TenDichVu,
                Gia = e.Gia,
                IsDelete = e.IsDelete
            });
            return lstdichvu.ToList();
        }
        public DichVu LayDichVu(int idDichVu)
        {
            var dichvu = models.DichVus.Where(e => e.ID == idDichVu).Select(e => new DichVu
            {
                ID = e.ID,
                TenDichVu = e.TenDichVu,
                Gia = e.Gia,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return dichvu;
        }
        public bool ThemDichVu(DichVu dichVu)
        {
            try
            {
                if (CheckDichVu(dichVu.TenDichVu)) {
                    Models.Entities.DichVu dv = new Models.Entities.DichVu();
                    dv.TenDichVu = dichVu.TenDichVu;
                    dv.Gia = dichVu.Gia;
                    dv.IsDelete = dichVu.IsDelete;
                    models.DichVus.Add(dv);
                    models.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return CheckDichVu(dichVu.TenDichVu);

        }
        public bool CapNhatDichVu(DichVu dichVu)
        {
            try
            {
                var dv = models.DichVus.Where(s => s.ID == dichVu.ID).FirstOrDefault();
                dv.TenDichVu = dichVu.TenDichVu;
                dv.Gia = dichVu.Gia;
               
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
        //TIENICH
        public List<TienIch> LayDanhSachTienIch()
        {
            var tienich = models.TienIches.Where(e => e.IsDelete == false).Select(e => new TienIch {
                ID = e.ID,
                TenTienIch = e.TenTienIch,
                HinhAnh = e.HinhAnh,
                IsDelete = e.IsDelete
            });
            return tienich.ToList();
        }
        public TienIch LayTienIch(int idtienich)
        {
            var tienich = models.TienIches.Where(e => e.ID == idtienich).Select(e => new TienIch
            {
                ID = e.ID,
                TenTienIch = e.TenTienIch,
                HinhAnh = e.HinhAnh,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return tienich;
        }
        public bool ThemTienIch(TienIch tienIch)
        {
            try
            {
                if (CheckTienIch(tienIch.TenTienIch))
                {
                    Models.Entities.TienIch tienich = new Models.Entities.TienIch();
                    tienich.TenTienIch = tienIch.TenTienIch;
                    tienich.HinhAnh = tienIch.HinhAnh;
                    tienich.IsDelete = tienIch.IsDelete;
                    models.TienIches.Add(tienich);
                    models.SaveChanges();
                }
             
            }
            catch (Exception)
            {
                throw;
            }
            return CheckTienIch(tienIch.TenTienIch);

        }
        public bool CapNhatTienIch(TienIch tienIch)
        {
            try
            {
                var tienich = models.TienIches.Where(s => s.ID == tienIch.ID).FirstOrDefault();
                tienich.TenTienIch = tienIch.TenTienIch;
                tienich.HinhAnh = tienIch.HinhAnh;
               
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
        //THONG KE
        public bool XuatThongKeTheoTuan(int idtuan)
        {
        
            return false;
        }
        public bool XuatThongKeTheoThang()
        {
            return false;
        }
        public bool XuatThongKeTheoNam()
        {
            return false;
        }
        public bool XuatThongKeTheoQuy()
        {
            return false;
        }
        #region
        private bool CheckTaiKhoan(string tenTaiKhoan)
        {
            bool b = true;
            List<TaiKhoan> lstTaiKhoan = models.TaiKhoans.Select(s => new TaiKhoan
            {
                TenTaiKhoan = s.TenTaiKhoan,
                MatKhau = s.MatKhau,
                HoVaTen = s.HoVaTen,
                SoDienThoai = s.SoDienThoai,
                Mail = s.Mail,
                LoaiTaiKhoan = s.LoaiTaiKhoan,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstTaiKhoan)
            {
                if (tenTaiKhoan.Equals(item.TenTaiKhoan)) { 
                    b = false;
                }
                else
                {
                    b = true;
                }
            }
            return b;
        }
        private bool CheckPhong(String soPhong)
        {
            bool b = true;
            List<Phong> lstPhong = models.Phongs.Select(s => new Phong {
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
            List<DichVu> lstDichVu = models.DichVus.Select(s => new DichVu
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
            List<TienIch> lstTienIch= models.TienIches.Select(s => new TienIch
            {
                TenTienIch = s.TenTienIch,
                HinhAnh = s.HinhAnh,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstTienIch)
            {
                if (tenTienIch.Equals(item.TenTienIch))
                    b = false;
            }
            return b;
        }
        #endregion
    }
}