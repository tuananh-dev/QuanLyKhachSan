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
        public bool LuuDoanDatPhongThanhCong(DatPhongThanhCong datPhongThanhCong)
        {
            try
            {
                models.DatPhongThanhCongs.Add(datPhongThanhCong);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool LuuDoanDatPhongThatBai(DatPhongThatBai datPhongThatBai)
        {
            try
            {
                models.DatPhongThatBais.Add(datPhongThatBai);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}