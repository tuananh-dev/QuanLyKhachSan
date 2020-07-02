using QLKSProject.Models;
using QLKSProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLKSProject.Business.NhanVien
{
    public class NhanVienBusiness : BaseBusiness
    {
        public List<Doan> LayDanhSachDoan()
        {
            var dsDoan = models.Doans.Select(s => s).ToList();
            return dsDoan;
        }

        public List<DatPhongThanhCong> LayDanhSachDatPhongThanhCong()
        {
            var datphongthanhcong = models.DatPhongThanhCongs.Select(s => s).ToList();

            return datphongthanhcong;
        }

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
        #endregion
    }
}