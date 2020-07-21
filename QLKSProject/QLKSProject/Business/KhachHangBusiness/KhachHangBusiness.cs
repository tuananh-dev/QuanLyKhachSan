using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models.DTO;

namespace QLKSProject.Business.KhachHangBusiness
{
    public class KhachHangBusiness: BaseBusiness
    {
        public List<KhachHangDTO> LayDanhSachKhachHangTheoMaDoan(string maDoan)
        {
            var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).Select(kh => new KhachHangDTO {
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
                TrangThaiDatPhong = kh.TrangThaiDatPhong
            }).ToList();

            return lstKhachHang;
        }
    }
}