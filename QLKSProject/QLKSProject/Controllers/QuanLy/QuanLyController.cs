﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.QuanLy;
using QLKSProject.Models.DTO;

namespace QLKSProject.Controllers.QuanLy
{
    public class QuanLyController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LayDanhSachTaiKhoan()
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                IHttpActionResult respon = Ok(quanLy.LayDanhSachTaiKhoan());
                return respon;
            }
        }
        [HttpGet]
        public IHttpActionResult LayTaiKhoan(dynamic dynamic)
        {
            IHttpActionResult respon;
            int idTaiKhoan = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayTaiKhoan(idTaiKhoan));
                return respon;
            }


        }
        [HttpPut]
        public IHttpActionResult CapNhatDichVu(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idDichVu = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatDichVu(idDichVu));
            }
            return respon;
        }
        /*
       [HttpPost]
       public bool ThemTaiKhoan(TaiKhoan taikhoan)
       {
           using (QuanLyBusiness quanLy = new QuanLyBusiness())
           {
               quanLy.ThemTaiKhoan(taikhoan);
               return true;
           }
       }
       [HttpGet]
       public List<Phong> LayDanhSachPhong()
       {
           using (QuanLyBusiness quanLy = new QuanLyBusiness())
           {

               return quanLy.LayDanhSachPhong(); ;
           }
       }
       [HttpPost]
       public bool ThemPhong (Phong phong)
       {
           using (QuanLyBusiness quanLy = new QuanLyBusiness())
           {
               quanLy.ThemPhong(phong);
               return true;
           }
       }
       [HttpGet]
       public List<DichVu> LayDanhSachDichVu()
       {
           using (QuanLyBusiness quanLy = new QuanLyBusiness())
           {

               return quanLy.LayDanhSachDichVu(); ;
           }
       }
       [HttpPost]
       public bool ThemDichVu(DichVu dichvu)
       {
           using (QuanLyBusiness quanLy = new QuanLyBusiness())
           {
               quanLy.ThemDichVu(dichvu);
               return true;
           }
       }
       [HttpGet]
       public List<TienIch> LayDanhSachTienIch()
       {
           using (QuanLyBusiness quanLy = new QuanLyBusiness())
           {

               return quanLy.LayDanhSachTienIch(); ;
           }
       }
       [HttpPost]
       public bool ThemTienIch(TienIch tienich)
       {
           using (QuanLyBusiness quanLy = new QuanLyBusiness())
           {
               quanLy.ThemTienIch(tienich);
               return true;
           }
       }*/
    }
}
