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
            /*
           [HttpPost]
           public bool ThemTaiKhoan(TaiKhoa n taikhoan)
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
