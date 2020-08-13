﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKSProject;
using QLKSProject.Models.DTO;
using QLKSProject.Business.QuanLy;

namespace QLKSProjectTest
{
    class Data_Test : BaseBusinessUnitTest
    {
        //Quan Ly
        #region DS Khach Hang
        public List<KhachHangDTO> DanhSachKhachHang()
        {
            var lstKH = new List<KhachHangDTO>();
            lstKH.Add(new KhachHangDTO { ID = 1, HoVaTen = "Lưu Vũ Đồng", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 2, HoVaTen = "Phạm Quang Đức", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 3, HoVaTen = "Phạm Quang Tín", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 4, HoVaTen = "Nguyễn Đức Tuấn Anh", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 5, HoVaTen = "Phan Đăng Lưu", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 6, HoVaTen = "Âu cơ", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 8, HoVaTen = "Lạc Long Quân", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 9, HoVaTen = "An Dương Vương", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            return lstKH;
        }
        #endregion
        #region TaiKhoan
        public string TaiKhoan()
        {
            return "{\"UserName\":\"tuangd\",\"UserPassword\":\"123456\",\"UserRoles\":\"ql\",\"PhoneNumber\":\"09483739455\",\"MaDoan\":\"0\",\"IsDelete\":\"false\",\"UserEmailID\":\"tuangd01@gmail.com\",\"UserID\":\"0\",\"FullName\":\"Nguyễn Đức Tuấn Anh\"}";
        }
        public UserMasterDTO TaiKhoanDuocLayMau()
        {
            UserMasterDTO userMaster = new UserMasterDTO();
            userMaster.ID = 132;
            userMaster.UserName = "anhnguyenduc";
            userMaster.UserPassword = "771417";
            userMaster.UserRoles = "nv";
            userMaster.UserEmailID = "anhnguyenduc@gmail.com";
            userMaster.FullName = "Nguyễn Đức Tuấn Anh";
            userMaster.PhoneNumber = "058059900";
            userMaster.UserID = 0;
            userMaster.MaDoan = "";
            userMaster.IsDelete = false;
            return userMaster;
        }
        public int DemSoLuongTaiKhoan()
        {
            var lstTKNhanVien = models.UserMasters.Where(t => t.IsDelete != true && t.UserRoles.Equals("nv")).ToList();
            return lstTKNhanVien.Count();
        }
        #endregion
        #region Phong
        public int DemSoLuongPhong()
        {
            return models.Phongs.Where(p => p.IsDelete != true).Count();
        }
        public PhongDTO LayThongTinPhong()
        {
            return models.Phongs.Select(e => new PhongDTO
            {
                ID = e.ID,
                MaPhong = e.MaPhong,
                SoPhong = e.SoPhong,
                LoaiPhong = e.LoaiPhong,
                Gia = e.Gia,
                TrangThai = e.TrangThai,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
        }
        public string TaoMoiPhong()
        {
            return "{\"MaPhong\":\"41235\",\"SoPhong\":\"1235\",\"LoaiPhong\":\"4\",\"Gia\":\"4000000\",\"TrangThai\":\"-1\",\"IsDelete\":\"false\"}";
        }
        #endregion
        #region Dich Vu
        public int SoLuongDichVu()
        {
            return models.DichVus.Where(d => d.IsDelete != true).Count();
        }
        public DichVuDTO LayThongTinDichVu()
        {
            return models.DichVus.Where(d => d.IsDelete != true).Select(d => new DichVuDTO
            {
                ID = d.ID,
                TenDichVu = d.TenDichVu,
                Gia = d.Gia,
                MoTa = d.MoTa,
                IsDelete = d.IsDelete
            }).FirstOrDefault();
        }
        public string TaoMoiDichVu()
        {
            return "{\"TenDichVu\":\"Karaoke\",\"MoTa\":\"Dan am thanh vo cung chat luong\",\"Gia\":\"3000000\",\"IsDelete\":\"false\"}";
        }
        public void PhucHoiDichVu(int id)
        {
            try
            {
                var dich_vu = models.DichVus.Where(d => d.ID == id).FirstOrDefault();
                dich_vu.IsDelete = false;
                models.SaveChanges();
            }
            catch (Exception)
            {
            }
            
        }
        #endregion
        #region Tien Ich
        public int SoLuongTienIch()
        {
            return models.TienIches.Where(t => t.IsDelete != true).Count();
        }
        public TienIchDTO LayThongTinTienIch()
        {
            return models.TienIches.Where(t => t.IsDelete != true).Select(t => new TienIchDTO
            {
                ID = t.ID,
                TenTienIch = t.TenTienIch,
                MoTa = t.MoTa,
                IsDelete = t.IsDelete
            }).FirstOrDefault();
        } 
        public string TaoMoiTienIch()
        {
            return "{\"TenTienIch\":\"Ban Công\",\"MoTa\":\"Ban công có view nhìn ra biển thoáng đãng\",\"IsDelete\":\"false\"}";
        }
        public List<ThongKeTheoThangDTO> BaoCaoThongKeTheoThang(int thang, int nam)
        {
            var business = new QuanLyBusiness();
            return business.BaoCaoThongKeTheoThang(thang, nam);
        }
        public SoSanhThongKeDTO SoSanhThongKeTheoThang(int thang, int nam)
        {
            var business = new QuanLyBusiness();
            return business.SoSanhThongKeTheoThang(thang, nam);
        }
        public SoSanhThongKeDTO SoSanhThongKeTheoQuy(int quy, int nam)
        {
            var business = new QuanLyBusiness();
            return business.SoSanhThongKeTheoQuy(quy, nam);
        }
        public void PhucHoiTienIchBiXoa(int id)
        {
            try
            {
                var tien_ich = models.TienIches.Where(t => t.ID == id).FirstOrDefault();
                tien_ich.IsDelete = false;
                models.SaveChanges();
            }
            catch (Exception)
            {

            }
            
        }
        #endregion
        //Nhan Vien
        public int SoLuongDoan()
        {
            return models.Doans.Where(d => d.IsDelete != true).Count();
        }
    }
}
