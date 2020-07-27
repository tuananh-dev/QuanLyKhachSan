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
        #region UserMaster
        public List<UserMasterDTO> LayDanhSachTaiKhoan()
        {
            var lstUserMaster = models.UserMasters.Where(e => e.IsDelete == false && e.UserRoles == "NV").Select(e => new UserMasterDTO
            {
                ID = e.ID,
                UserName = e.UserName,
                UserPassword = e.UserPassword,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                UserEmailID = e.UserEmailID,
                UserRoles = e.UserRoles,
                IsDelete = e.IsDelete
            });
            return lstUserMaster.ToList();
        }
        public UserMasterDTO LayTaiKhoan(int idUserMaster)
        {

            var UserMaster = models.UserMasters.Where(e => e.ID == idUserMaster).Select(e => new UserMasterDTO
            {
                ID = e.ID,
                UserName = e.UserName,
                UserPassword = e.UserPassword,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                UserEmailID = e.UserEmailID,
                UserRoles = e.UserRoles,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return UserMaster;
        }
        public bool ThemTaiKhoan(UserMasterDTO UserMaster)
        {

            Models.Entities.UserMaster tk = new Models.Entities.UserMaster();
            if (CheckUserMaster(UserMaster.UserName))
            {
                tk.UserName = UserMaster.UserName;
                tk.UserPassword = UserMaster.UserPassword;
                tk.FullName = UserMaster.FullName;
                tk.PhoneNumber = UserMaster.PhoneNumber;
                tk.UserEmailID = UserMaster.UserEmailID;
                tk.UserRoles = UserMaster.UserRoles;
                tk.IsDelete = UserMaster.IsDelete;
                models.UserMasters.Add(tk);
                models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CapNhatTaiKhoan(UserMasterDTO UserMaster)
        {

            try
            {
                var tk = models.UserMasters.Where(s => s.ID == UserMaster.ID).FirstOrDefault();
                tk.UserName = UserMaster.UserName;
                tk.FullName = UserMaster.FullName;
                tk.PhoneNumber = UserMaster.PhoneNumber;
                tk.UserEmailID = UserMaster.UserEmailID;
                tk.UserRoles = UserMaster.UserRoles;
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaTaiKhoan(int idUserMaster)
        {
            var UserMaster = models.UserMasters.Where(e => e.ID == idUserMaster).FirstOrDefault();
            if (UserMaster != null)
            {
                UserMaster.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion
        #region Phong
        public List<PhongDTO> LayDanhSachPhong()
        {
            DateTime today = DateTime.Now;
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
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiXacNhan != false).Select(kh => new KhachHangDTO
            {
                ID = kh.ID,
                HoVaTen = kh.HoVaTen,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                DiaChi = kh.DiaChi,
                Nhom = kh.Nhom,
                NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm,
                ThoiGianNhan = kh.ThoiGianNhan,
                ThoiGianTra = kh.ThoiGianTra,
                MaDoan = kh.MaDoan,
                GioiTinh = kh.GioiTinh,
                LoaiKhachHang = kh.LoaiKhachHang,
                TruongDoan = kh.TruongDoan,
                IsDelete = kh.IsDelete,
                TrangThaiDatPhong = kh.TrangThaiDatPhong,
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();
            foreach (var phong in lstphong)
            {
                var lstKhachHangPhong = lstKhachHang.Where(kh => kh.IDPhong == phong.ID).ToList();
                foreach (var kh in lstKhachHangPhong)
                {
                    if (kh.ThoiGianNhan.CompareTo(today) <= 0 && kh.ThoiGianTra.CompareTo(today) >= 1)
                        phong.TrangThai = false;
                }
            }
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
            var lstdichvu = models.DichVus.Where(e => e.IsDelete == false).Select(e => new DichVuDTO
            {
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
            if (CheckDichVu(dichVu.TenDichVu))
            {

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
            var tienich = models.TienIches.Where(e => e.IsDelete == false).Select(e => new TienIchDTO
            {
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

            }
            catch (Exception)

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
        public List<ThongKeTheoThangDTO> BaoCaoThongKeTheoThang(int thang, int nam)
        {
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong != false).Select(kh => new KhachHangDTO
            {
                ID = kh.ID,
                HoVaTen = kh.HoVaTen,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                DiaChi = kh.DiaChi,
                Nhom = kh.Nhom,
                NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm,
                ThoiGianNhan = kh.ThoiGianNhan,
                ThoiGianTra = kh.ThoiGianTra,
                MaDoan = kh.MaDoan,
                GioiTinh = kh.GioiTinh,
                LoaiKhachHang = kh.LoaiKhachHang,
                TruongDoan = kh.TruongDoan,
                IsDelete = kh.IsDelete,
                TrangThaiDatPhong = kh.TrangThaiDatPhong,
                IDPhong = kh.IDPhong,
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();
            var lstPhong = models.Phongs.Where(p => p.IsDelete != true).Select(p => new PhongDTO
            {
                ID = p.ID,
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.LoaiPhong,
                Gia = p.Gia,
                TrangThai = p.TrangThai,
                IsDelete = p.IsDelete
            }).ToList();
            List<ThongKeTheoThangDTO> lstBaoCaoThongKeDTO = new List<ThongKeTheoThangDTO>();
            lstBaoCaoThongKeDTO.Add(DoanhThuChoThuePhong(thang, nam, lstPhong, lstKhachHang));
            lstBaoCaoThongKeDTO.Add(DoanhThuAnUong());
            lstBaoCaoThongKeDTO.Add(DoanhThuGiatUi());
            lstBaoCaoThongKeDTO.Add(DoanhThuThueXe());
            lstBaoCaoThongKeDTO.Add(DoanhThuMassage());

            return lstBaoCaoThongKeDTO;
        }
        public List<ThongKeTheoQuyDTO> BaoCaoThongKeTheoQuy(int quy, int nam)
        {
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong != false).Select(kh => new KhachHangDTO
            {
                ID = kh.ID,
                HoVaTen = kh.HoVaTen,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                DiaChi = kh.DiaChi,
                Nhom = kh.Nhom,
                NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm,
                ThoiGianNhan = kh.ThoiGianNhan,
                ThoiGianTra = kh.ThoiGianTra,
                MaDoan = kh.MaDoan,
                GioiTinh = kh.GioiTinh,
                LoaiKhachHang = kh.LoaiKhachHang,
                TruongDoan = kh.TruongDoan,
                IsDelete = kh.IsDelete,
                TrangThaiDatPhong = kh.TrangThaiDatPhong,
                IDPhong = kh.IDPhong,
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();
            var lstPhong = models.Phongs.Where(p => p.IsDelete != true).Select(p => new PhongDTO
            {
                ID = p.ID,
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.LoaiPhong,
                Gia = p.Gia,
                TrangThai = p.TrangThai,
                IsDelete = p.IsDelete
            }).ToList();
            int thang1 = 1;
            int thang2 = 2;
            int thang3 = 3;
            switch (quy)
            {
                case 1: break;
                case 2:
                    thang1 = 4;
                    thang2 = 5;
                    thang3 = 6;
                    break;
                case 3:
                    thang1 = 7;
                    thang2 = 8;
                    thang3 = 9;
                    break;
                case 4:
                    thang1 = 10;
                    thang2 = 11;
                    thang3 = 12;
                    break;
            }
            List<ThongKeTheoQuyDTO> thongKeTheoQuyDTOs = new List<ThongKeTheoQuyDTO>();
            thongKeTheoQuyDTOs.Add(DoanhThuChoThuePhongTheoQuy(thang1, thang2, thang3, nam, lstPhong, lstKhachHang));
            thongKeTheoQuyDTOs.Add(DoanhThuAnUongTheoQuy());
            thongKeTheoQuyDTOs.Add(DoanhThuMassageTheoQuy());
            thongKeTheoQuyDTOs.Add(DoanhThuThueXeTheoQuy());
            thongKeTheoQuyDTOs.Add(DoanhThuGiatUiTheoQuy());

            return thongKeTheoQuyDTOs;
        }
        #endregion
        #region Private Methods
        private bool CheckUserMaster(String userName)
        {
            bool b = true;
            List<UserMasterDTO> lstUserMaster = models.UserMasters.Select(s => new UserMasterDTO
            {
                UserName = s.UserName,
                UserPassword = s.UserPassword,
                FullName = s.FullName,
                PhoneNumber = s.PhoneNumber,
                UserEmailID = s.UserEmailID,
                UserRoles = s.UserRoles,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstUserMaster)
            {
                if (userName.Equals(item.UserName))
                    b = false;

            }
            return b;
        }
        private bool CheckPhong(String soPhong)
        {
            bool b = true;
            List<PhongDTO> lstPhong = models.Phongs.Select(s => new PhongDTO
            {
                MaPhong = s.MaPhong,
                SoPhong = s.SoPhong,
                LoaiPhong = s.LoaiPhong,
                Gia = s.Gia,
                TrangThai = s.TrangThai,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstPhong)
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
            List<TienIchDTO> lstTienIch = models.TienIches.Select(s => new TienIchDTO
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
        private int TinhNgayCuoiThang(int thang, int nam)
        {
            int soNgay = 0;
            bool testNamNhuan = false;
            //Kiem tra nam nhuan
            if ((nam % 400) == 0)
                testNamNhuan = true;
            else if ((nam % 100) == 0)
                testNamNhuan = false;
            else if ((nam % 4) == 0)
                testNamNhuan = true;
            else
                testNamNhuan = false;
            //Kiem tra thang
            switch (thang)
            {
                case 1: soNgay = 31; break;
                case 2: soNgay = testNamNhuan ? 29 : 28; break;
                case 3: soNgay = 31; break;
                case 4: soNgay = 30; break;
                case 5: soNgay = 31; break;
                case 6: soNgay = 30; break;
                case 7: soNgay = 31; break;
                case 8: soNgay = 31; break;
                case 9: soNgay = 30; break;
                case 10: soNgay = 31; break;
                case 11: soNgay = 30; break;
                case 12: soNgay = 31; break;
            }
            return soNgay;
        }
        private ThongKeTheoThangDTO DoanhThuChoThuePhong(int thang, int nam, List<PhongDTO> phongDTOs, List<KhachHangDTO> khachHangDTOs)
        {
            int cuoiThang = TinhNgayCuoiThang(thang, nam);
            double doanhThu = 0;
            foreach (var phong in phongDTOs)
            {
                var lstKhachHangTheoPhong = khachHangDTOs.Where(kh => kh.IDPhong == phong.ID && kh.ThoiGianTra.Year == nam && kh.ThoiGianTra.Month == thang).GroupBy(kh => kh.ThoiGianNhan).ToList();

                foreach (var key in lstKhachHangTheoPhong)
                {
                    var khachHang = key.FirstOrDefault();
                    if (KiemTraThoiGianDatPhong(khachHang.ThoiGianTra, cuoiThang))
                    {
                        TimeSpan timeSpan = khachHang.ThoiGianTra - khachHang.ThoiGianNhan;
                        int soNgay = timeSpan.Days;
                        doanhThu += phong.Gia * soNgay;
                    }
                }
            }
            ThongKeTheoThangDTO baoCaoThongKe = new ThongKeTheoThangDTO();
            baoCaoThongKe.TenDichVu = "Cho thuê phòng";
            baoCaoThongKe.DoanThu = doanhThu;
            return baoCaoThongKe;
        }
        private bool KiemTraThoiGianDatPhong(DateTime ngayTra, int cuoiThang)
        {
            int ngayTraPhong = ngayTra.Day;
            if (ngayTraPhong >= 1 && ngayTraPhong <= cuoiThang)
                return true;
            else
                return false;
        }
        private ThongKeTheoThangDTO DoanhThuAnUong()
        {
            ThongKeTheoThangDTO baoCaoThongKe = new ThongKeTheoThangDTO();
            baoCaoThongKe.TenDichVu = "Ăn uống";
            baoCaoThongKe.DoanThu = 10000000;
            return baoCaoThongKe;
        }
        private ThongKeTheoThangDTO DoanhThuMassage()
        {
            ThongKeTheoThangDTO baoCaoThongKe = new ThongKeTheoThangDTO();
            baoCaoThongKe.TenDichVu = "Massage";
            baoCaoThongKe.DoanThu = 10000000;
            return baoCaoThongKe;
        }
        private ThongKeTheoThangDTO DoanhThuThueXe()
        {
            ThongKeTheoThangDTO baoCaoThongKe = new ThongKeTheoThangDTO();
            baoCaoThongKe.TenDichVu = "Thuê Xe";
            baoCaoThongKe.DoanThu = 10000000;
            return baoCaoThongKe;
        }
        private ThongKeTheoThangDTO DoanhThuGiatUi()
        {
            ThongKeTheoThangDTO baoCaoThongKe = new ThongKeTheoThangDTO();
            baoCaoThongKe.TenDichVu = "Giặt ủi";
            baoCaoThongKe.DoanThu = 10000000;
            return baoCaoThongKe;
        }
        private ThongKeTheoQuyDTO DoanhThuChoThuePhongTheoQuy(int thang1,int thang2,int thang3, int nam, List<PhongDTO> phongDTOs, List<KhachHangDTO> khachHangDTOs)
        {    
            var doanhThuChoThuePhongThang1 = DoanhThuChoThuePhong(thang1, nam, phongDTOs, khachHangDTOs);
            var doanhThuChoThuePhongThang2 = DoanhThuChoThuePhong(thang2, nam, phongDTOs, khachHangDTOs);
            var doanhThuChoThuePhongThang3 = DoanhThuChoThuePhong(thang3, nam, phongDTOs, khachHangDTOs);
            ThongKeTheoQuyDTO thongKeTheoQuyDTO = new ThongKeTheoQuyDTO();
            thongKeTheoQuyDTO.TenDichVu = doanhThuChoThuePhongThang1.TenDichVu;
            thongKeTheoQuyDTO.DoanhThu1 = doanhThuChoThuePhongThang1.DoanThu;
            thongKeTheoQuyDTO.DoanhThu2 = doanhThuChoThuePhongThang2.DoanThu;
            thongKeTheoQuyDTO.DoanhThu3 = doanhThuChoThuePhongThang3.DoanThu;
            thongKeTheoQuyDTO.TrungBinh = (doanhThuChoThuePhongThang1.DoanThu + doanhThuChoThuePhongThang2.DoanThu + doanhThuChoThuePhongThang3.DoanThu) / 3;
            return thongKeTheoQuyDTO;
        }
        private ThongKeTheoQuyDTO DoanhThuAnUongTheoQuy()
        {
            ThongKeTheoQuyDTO thongKeTheoQuy = new ThongKeTheoQuyDTO();
            thongKeTheoQuy.TenDichVu = "Ăn uống";
            thongKeTheoQuy.DoanhThu1 = 10000000;
            thongKeTheoQuy.DoanhThu2 = 10000000;
            thongKeTheoQuy.DoanhThu3 = 10000000;
            thongKeTheoQuy.TrungBinh = 10000000;
            return thongKeTheoQuy;
        }
        private ThongKeTheoQuyDTO DoanhThuMassageTheoQuy()
        {
            ThongKeTheoQuyDTO thongKeTheoQuy = new ThongKeTheoQuyDTO();
            thongKeTheoQuy.TenDichVu = "Massage";
            thongKeTheoQuy.DoanhThu1 = 10000000;
            thongKeTheoQuy.DoanhThu2 = 10000000;
            thongKeTheoQuy.DoanhThu3 = 10000000;
            thongKeTheoQuy.TrungBinh = 10000000;
            return thongKeTheoQuy;
        }
        private ThongKeTheoQuyDTO DoanhThuThueXeTheoQuy()
        {
            ThongKeTheoQuyDTO thongKeTheoQuy = new ThongKeTheoQuyDTO();
            thongKeTheoQuy.TenDichVu = "Thuê Xe";
            thongKeTheoQuy.DoanhThu1 = 10000000;
            thongKeTheoQuy.DoanhThu2 = 10000000;
            thongKeTheoQuy.DoanhThu3 = 10000000;
            thongKeTheoQuy.TrungBinh = 10000000;
            return thongKeTheoQuy;
        }
        private ThongKeTheoQuyDTO DoanhThuGiatUiTheoQuy()
        {
            ThongKeTheoQuyDTO thongKeTheoQuy = new ThongKeTheoQuyDTO();
            thongKeTheoQuy.TenDichVu = "Giặt ủi";
            thongKeTheoQuy.DoanhThu1 = 10000000;
            thongKeTheoQuy.DoanhThu2 = 10000000;
            thongKeTheoQuy.DoanhThu3 = 10000000;
            thongKeTheoQuy.TrungBinh = 10000000;
            return thongKeTheoQuy;
        }
        #endregion
    }
}