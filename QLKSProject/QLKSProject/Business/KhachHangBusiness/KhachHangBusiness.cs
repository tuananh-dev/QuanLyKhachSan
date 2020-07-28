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
            var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan && kh.IsDelete != true).Select(kh => new KhachHangDTO {
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
<<<<<<< HEAD
                IDPhong = kh.IDPhong,
=======
>>>>>>> 75154cee969209a139d29339bbb28d918adfd855
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();

            return lstKhachHang;
        }
        public bool XacNhanDatPhong(string maDoan)
        {
            bool b = false;
            var doan = models.Doans.Where(d => d.MaDoan == maDoan).FirstOrDefault();
            if(doan != null)
            {
                doan.TrangThaiXacNhan = true;
                b = true;
            }
            else
                b = false;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).ToList();
            if (lstKhachHang.Count != 0)
            {
                foreach (var khachHang in lstKhachHang)
                {
                    khachHang.TrangThaiXacNhan = true;
                }
                b = true;
                models.SaveChanges();
            }
            else
                b = false;
            return b;
        }
        public string HuyDatPhong(string maDoan)
        {
            string error = "ok";
            try
            {
                var doan = models.Doans.Where(d => d.MaDoan == maDoan).FirstOrDefault();
                var taiKhoan = models.UserMasters.Where(tk => tk.MaDoan == maDoan).FirstOrDefault();
                taiKhoan.IsDelete = true;
                if(doan.TrangThaiXacNhan != true)
                {
                    doan.IsDelete = true;
                    var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).ToList();
                    foreach (var kh in lstKhachHang)
                    {
                        kh.IsDelete = true;
                    }
                    models.SaveChanges();
                }else
                    error = "Hủy danh sách khách hàng lỗi!";
            }
            catch (Exception)
            {
                error = "Hủy danh sách khách hàng lỗi!";
            }
            return error;
        }
    }
}