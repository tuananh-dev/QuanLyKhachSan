using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
          
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
            }
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
                Models.Entities.Phong ph = new Models.Entities.Phong();
                ph.MaPhong = phong.MaPhong;
                ph.SoPhong = phong.SoPhong;
                ph.LoaiPhong = phong.LoaiPhong;
                ph.Gia = phong.Gia;
                ph.IsDelete = phong.IsDelete;
                models.Phongs.Add(ph);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


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
                Models.Entities.DichVu dv = new Models.Entities.DichVu();
                dv.TenDichVu = dichVu.TenDichVu;
                dv.Gia = dichVu.Gia;
                dv.IsDelete = dichVu.IsDelete;
                models.DichVus.Add(dv);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


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
                Models.Entities.TienIch tienich = new Models.Entities.TienIch();
                tienich.TenTienIch = tienIch.TenTienIch;
                tienich.HinhAnh = tienIch.HinhAnh;
                tienich.IsDelete = tienIch.IsDelete;
                models.TienIches.Add(tienich);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


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