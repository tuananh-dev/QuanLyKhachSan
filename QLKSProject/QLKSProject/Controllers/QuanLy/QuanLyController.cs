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
        public IHttpActionResult ThemTaiKhoan(TaiKhoan taiKhoan)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                    
                    respon = Ok(quanLy.ThemTaiKhoan(taiKhoan));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatTaiKhoan(TaiKhoan taiKhoan)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatTaiKhoan(taiKhoan));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaTaiKhoan(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idTaiKhoan = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaTaiKhoan(idTaiKhoan));
                return respon;
            }
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
        [HttpPost]
        public IHttpActionResult ThemPhong(Phong phong)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.ThemPhong(phong));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatPhong(Phong phong)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatPhong(phong));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaPhong(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idPhong = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaPhong(idPhong));
                return respon;
            }
        }
        //DICHVU
        [HttpGet]
        public IHttpActionResult LayDanhSachDichVu()
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
        [HttpPost]
        public IHttpActionResult ThemDichVu(DichVu dichVu)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.ThemDichVu(dichVu));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatDichVu(DichVu dichVu)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatDichVu(dichVu));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaDichVu(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idDichVu = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaDichVu(idDichVu));
                return respon;
            }
        }
        //TIENICH
        [HttpGet]
        public IHttpActionResult LayDanhSachTienIch()
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

        [HttpPost]
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

        [HttpPost]
        public IHttpActionResult ThemTienIch(TienIch tienIch)

        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.ThemTienIch(tienIch));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatTienIch(TienIch tienIch)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatTienIch(tienIch));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaTienIch(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            int idTienIch = int.Parse(dynamic.ID.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaTienIch(idTienIch));
                return respon;
            }
        }

    }
}
