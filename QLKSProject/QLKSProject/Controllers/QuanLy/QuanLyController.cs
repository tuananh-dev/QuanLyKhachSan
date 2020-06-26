using QLKSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.QuanLy;

namespace QLKSProject.Controllers.QuanLy
{
    public class QuanLyController : ApiController
    {

        //TAIKHOAN
        [HttpGet]
        public List<TaiKhoan> LayDanhSachTaiKhoan()
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {

                return quanLy.LayDanhSachTaiKhoan() ;
            }
        }
        [HttpPost]
        public bool ThemTaiKhoan(TaiKhoan taikhoan)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                quanLy.ThemTaiKhoan(taikhoan);
                return true;
            }
        }

        //PHONG
        [HttpGet]
        public List<Phong> LayDanhSachPhong()
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {

                return quanLy.LayDanhSachPhong();
            }
        }
        [HttpPost]
        public bool ThemPhong(Phong phong)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                quanLy.ThemPhong(phong);
                return true;
            }
        }
        ////DICHVU
        //[HttpGet]
        //public List<DichVu> LayDanhSachDichVu()
        //{
        //    using (QuanLyBusiness quanLy = new QuanLyBusiness())
        //    {

        //        return quanLy.LayDanhSachDichVu();
        //    }
        //}
        //[HttpPost]
        //public bool ThemDichVu(DichVu dichvu)
        //{
        //    using (QuanLyBusiness quanLy = new QuanLyBusiness())
        //    {
        //        quanLy.ThemDichVu(dichvu);
        //        return true;
        //    }
        //}
        ////TIENICH
        //[HttpGet]
        //public List<TienIch> LayDanhSachTienIch()
        //{
        //    using (QuanLyBusiness quanLy = new QuanLyBusiness())
        //    {

        //        return quanLy.LayDanhSachTienIch();
        //    }
        //}
        //[HttpPost]
        //public bool ThemTienIch(TienIch tienich)
        //{
        //    using (QuanLyBusiness quanLy = new QuanLyBusiness())
        //    {
        //        quanLy.ThemTienIch(tienich);
        //        return true;
        //    }
        //}
    }
}
