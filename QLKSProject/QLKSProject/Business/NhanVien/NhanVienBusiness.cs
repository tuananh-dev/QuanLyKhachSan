using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLKSProject.Business.NhanVien
{
    public class NhanVienBusiness : BaseBusiness
    {
        #region Public Methods
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
        public List<DatPhongThanhCong> LayDanhSachDatPhongThanhCong()
        {
            var lstdatPhongThanhCongs = models.DatPhongThanhCongs.Select(s => new DatPhongThanhCong
            {
                ID = s.ID,
                IDKhachHang = s.IDKhachHang,
                IDPhong = s.IDPhong,
                IsDelete = s.IsDelete,
                NgayTraPhongThucTe = s.NgayTraPhongThucTe
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
        #endregion

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
        private List<KhachHang> LayDanhSachKhachHangTheoDoan(string maDoan)
        {
            var lstKhachHang = models.KhachHangs.Where(s => s.MaDoan.Equals(maDoan)).Select(s => new KhachHang {
                ID = s.ID,
                HoVaTen = s.HoVaTen,
                SoDienThoai = s.SoDienThoai,
                Email = s.Email,
                DiaChi = s.DiaChi,
                Nhom = s.Nhom,
                NguoiDaiDienCuaTreEm = s.NguoiDaiDienCuaTreEm,
                ThoiGianNhan = s.ThoiGianNhan,
                ThoiGianTra = s.ThoiGianTra,
                MaDoan = s.MaDoan,
                GioiTinh = s.GioiTinh,
                LoaiKhachHang = s.LoaiKhachHang,
                TruongDoan = s.TruongDoan,
                IsDelete = s.IsDelete
            }).ToList();
            return lstKhachHang;
        }
        private List<int> LayDSNhomTrongDSKhachHang(List<KhachHang> lstKhachHang)
        {
            var lstNhom = lstKhachHang.GroupBy(s => s.Nhom).Select(g => g.Key).ToList();                             
            return lstNhom;
        }
        private bool KiemTraTreEmCoTrongDanhSach (List<KhachHang> lstKhachHang)
        {
            foreach (var item in lstKhachHang)
            {
                if (item.LoaiKhachHang.Equals("tre"))
                    return true;
            }
            return false;
        }

        #endregion

    }
}