using System;
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
        //TAIKHOAN
        [HttpGet]
        public IHttpActionResult LayDanhSachTaiKhoan()
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.LayDanhSachTaiKhoan() != null)
                {
                    respon = Ok(quanLy.LayDanhSachTaiKhoan());
                }
                else
                {
                    respon = Ok("Không có dữ liệu");
                }
                return respon;
            }
        }
        [HttpGet]
        public IHttpActionResult LayTaiKhoan(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idTaiKhoan = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {                
                    respon = Ok(quanLy.LayTaiKhoan(idTaiKhoan));                             
                return respon;
            }

        }
        [HttpPost]
        public IHttpActionResult CapNhatTaiKhoan(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            return respon;

        }
        //PHONG
        [HttpGet]
        public IHttpActionResult LayDanhSachPhong()
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.LayDanhSachPhong() != null)
                {
                    respon = Ok(quanLy.LayDanhSachPhong());
                }
                else
                {
                    respon = Ok("Không có dữ liệu");
                }
                return respon;
            }
        }
        [HttpGet]
        public IHttpActionResult LayPhong(dynamic dynamic)
        {
            IHttpActionResult respon;
            int idPhong = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayPhong(idPhong));
                return respon;
            }
        }
        //DICHVU
        [HttpGet]
        public IHttpActionResult LayDanhDichVu()
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.LayDanhSachDichVu() != null)
                {
                    respon = Ok(quanLy.LayDanhSachDichVu());
                }
                else
                {
                    respon = Ok("Không có dữ liệu");
                }
                return respon;
            }
        }

        [HttpGet]
        public IHttpActionResult LayDichVu(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idDichVu = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayDichVu(idDichVu));
                return respon;
            }
        }

        //TIENICH
        [HttpGet]
        public IHttpActionResult LayDanhTienIch()
        {
                IHttpActionResult respon = Ok();
                using (QuanLyBusiness quanLy = new QuanLyBusiness())
                {
                    if (quanLy.LayDanhSachTienIch() != null)
                    {
                        respon = Ok(quanLy.LayDanhSachTienIch());
                    }
                    else
                    {
                        respon = Ok("Không có dữ liệu");
                    }
                    return respon;
                }
            }
        
        [HttpGet]
        public IHttpActionResult LayTienIch(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idTienIch = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayTienIch(idTienIch));
                return respon;
            }
        }
        }
}
