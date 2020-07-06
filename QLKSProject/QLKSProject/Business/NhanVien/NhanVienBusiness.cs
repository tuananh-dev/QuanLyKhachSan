using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLKSProject.Business.NhanVien
{
    public class NhanVienBusiness : BaseBusiness
    {

        public List<Doan> LayDanhSachDoan()
        {
            var lstDoan = models.Doans.Select(s => new Doan
            {
                ID = s.ID,
                MaDoan = s.MaDoan,
                TenDoan = s.TenDoan,
                NgayGui = s.NgayGui,
                TenTruongDoan = s.TenTruongDoan,
                ThoiGianNhan = s.ThoiGianNhan,
                ThoiGianTra = s.ThoiGianTra,
                IsDelete = s.IsDelete,
            });
            return lstDoan.ToList();
        }
<<<<<<< HEAD

        public List<DatPhongThanhCong> LayDanhSachDatPhongThanhCong()
        {
            var datPhongThanhCongs = models.DatPhongThanhCongs.Select(s => new DatPhongThanhCong
=======
        public List<DatPhongThanhCong> LayDanhSachDatPhongThanhCong()
        {
            var lstdatPhongThanhCongs = models.DatPhongThanhCongs.Select(s => new DatPhongThanhCong
>>>>>>> 56bf1b3d7694bce56da28206eb39c7b2ebcd860a
            {
                ID = s.ID,
                IDKhachHang = s.IDKhachHang,
                IDPhong = s.IDPhong,
                IsDelete = s.IsDelete,
                NgayTraPhongThucTe = s.NgayTraPhongThucTe
<<<<<<< HEAD
            }).ToList();

            return datPhongThanhCongs;
        }
        /*
               public List<DatPhongThatBai> LayDanhSachDatPhongThatBai()
               {
                   var datphongthatbai = models.DatPhongThatBais.Select(s => s).ToList();
                   return datphongthatbai;
               }
               #region private methods
               private bool LuuDatPhongThanhCong(KhachHang khachHangs, int IDPhong)
               {
                   DatPhongThanhCong datPhongThanhCong = new DatPhongThanhCong();
                   datPhongThanhCong.IDPhong = IDPhong;
                   datPhongThanhCong.IDKhachHang = khachHangs.ID;
                   datPhongThanhCong.NgayTraPhongThucTe = khachHangs.ThoiGianTra;
                   datPhongThanhCong.IsDelete = false;

                   try
                   {
                       models.DatPhongThanhCongs.Add(datPhongThanhCong);
                       return true;
                   }
                   catch
                   {
                       Console.WriteLine("Lưu bảng thành công!");
                       return false;
                   }
               }
               private bool LuuDatPhongThatBai(KhachHang khachHangs, int IDKhachHang)
               {
                   DatPhongThatBai datPhongThatBai = new DatPhongThatBai();
                   datPhongThatBai.ID = IDKhachHang;
                   datPhongThatBai.MaDoan = khachHangs.MaDoan;
                   datPhongThatBai.IsDelete = false;

                   try
                   {
                       models.DatPhongThatBais.Add(datPhongThatBai);
                       return true;
                   }
                   catch
                   {
                       Console.WriteLine("Lưu bảng thành công!");
                       return false;
                   }
               }
               #endregion*/
=======
            });
            return lstdatPhongThanhCongs.ToList();
        }
        public List<DatPhongThatBai> LayDanhSachDatPhongThatBai()
        {
            var datPhongThatBais = models.DatPhongThatBais.Select(s => new DatPhongThatBai
            {
                ID = s.ID,
                TenDoan = s.TenDoan,
                MaDoan = s.MaDoan,
                IsDelete = s.IsDelete,
                GhiChu = s.GhiChu
            });
            return datPhongThatBais.ToList();
        }

        #region private methods
        private bool LuuDatPhongThanhCong(KhachHang khachHangs, int IDPhong)
        {
            try
            {
                Models.Entities.DatPhongThanhCong datPhongThanhCong = new Models.Entities.DatPhongThanhCong();
                datPhongThanhCong.IDPhong = IDPhong;
                datPhongThanhCong.IDKhachHang = khachHangs.ID;
                datPhongThanhCong.NgayTraPhongThucTe = khachHangs.ThoiGianTra;
                datPhongThanhCong.IsDelete = false;

                models.DatPhongThanhCongs.Add(datPhongThanhCong);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
 
        }
        private bool LuuDatPhongThatBai(KhachHang khachHangs, int IDKhachHang)
        {
            try
            {
                Models.Entities.DatPhongThatBai datPhongThatBai = new Models.Entities.DatPhongThatBai();
                datPhongThatBai.ID = IDKhachHang;
                datPhongThatBai.MaDoan = khachHangs.MaDoan;
                datPhongThatBai.IsDelete = false;

                models.DatPhongThatBais.Add(datPhongThatBai);
                return true;
            }
            catch
            {            
                return false;
            }
        }
        #endregion
>>>>>>> 56bf1b3d7694bce56da28206eb39c7b2ebcd860a
    }
}