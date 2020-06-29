﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.NhanVien;
using QLKSProject.Models;
using QLKSProject.Models.Entities;

namespace QLKSProject.Controllers.NhanVien
{
    public class NhanVienController : ApiController
    {
        [HttpPost]
        public List<Doan> LayDanhSachDoan()
        {
            using (NhanVienBusiness nhanvien = new NhanVienBusiness())
            {
                return nhanvien.LayDanhSachDoan();
            }
        }
        [HttpPost]
        public List<DatPhongThanhCong> LayDanhSachDatPhongThanhCong()
        {
            using (NhanVienBusiness datphongthanhcong = new NhanVienBusiness())
            {
                return datphongthanhcong.LayDanhSachDatPhongThanhCong();
            }
        }
        [HttpPost]
        public List<DatPhongThatBai> LayDanhSachDatPhongThatBai()
        {
            using (NhanVienBusiness datphongthatbai = new NhanVienBusiness())
            {
                return datphongthatbai.LayDanhSachDatPhongThatBai();
            }
        }
        [HttpPost]
        public bool LuuDoanDatPhongThanhCong(DatPhongThanhCong datPhongThanhCong)
        {
            using (NhanVienBusiness doan = new NhanVienBusiness())
            {
                doan.LuuDoanDatPhongThanhCong(datPhongThanhCong);
                return true;
            }
        }
        [HttpPost]
        public bool LuuDoanDatPhongThatBai(DatPhongThatBai datPhongThatBai)
        {
            using (NhanVienBusiness doan = new NhanVienBusiness())
            {
                doan.LuuDoanDatPhongThatBai(datPhongThatBai);
                return true;
            }
        }
    }
}
