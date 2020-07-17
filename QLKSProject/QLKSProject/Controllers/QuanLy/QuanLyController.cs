using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using QLKSProject.Business.QuanLy;
using QLKSProject.Models.DTO;

namespace QLKSProject.Controllers.QuanLy
{
    public class QuanLyController : ApiController
    {
        #region API xu ly TaiKhoan
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
        public IHttpActionResult LayTaiKhoan([FromUri] int id)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayTaiKhoan(id));
                return respon;
            }

        }
        [HttpPost]
        public IHttpActionResult ThemTaiKhoan([FromBody]dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            TaiKhoan tk = JsonConvert.DeserializeObject<TaiKhoan>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            { 
                    respon = Ok(quanLy.ThemTaiKhoan(tk));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatTaiKhoan([FromBody] dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            TaiKhoan tk = JsonConvert.DeserializeObject<TaiKhoan>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatTaiKhoan(tk));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaTaiKhoan([FromUri]int id)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaTaiKhoan(id));
                return respon;
            }
        }
        #endregion
        #region API xu ly Phong
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
        public IHttpActionResult LayPhong([FromUri]int id)
        {
            IHttpActionResult respon;
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayPhong(id));
                return respon;
            }
        }
        [HttpPost]
        public IHttpActionResult ThemPhong([FromBody]dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            Phong ph = JsonConvert.DeserializeObject<Phong>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.ThemPhong(ph));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatPhong([FromBody] dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            Phong ph = JsonConvert.DeserializeObject<Phong>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatPhong(ph));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaPhong([FromUri]int id)
        {
            IHttpActionResult respon = Ok();            
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaPhong(id));
                return respon;
            }
        }
        #endregion
        #region API xu ly DichVu
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
        public IHttpActionResult LayDichVu([FromUri] int id)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayDichVu(id));
                return respon;
            }
        }
        [HttpPost]
        public IHttpActionResult ThemDichVu([FromBody]dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            DichVu dv = JsonConvert.DeserializeObject<DichVu>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.ThemDichVu(dv));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatDichVu([FromBody]dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            DichVu dv = JsonConvert.DeserializeObject<DichVu>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatDichVu(dv));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaDichVu([FromUri]int id)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaDichVu(id));
                return respon;
            }
        }
        #endregion
        #region API xu ly TienIch
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

        [HttpGet]
        public IHttpActionResult LayTienIch([FromUri]int id)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.LayTienIch(id));
                return respon;
            }
        }

        [HttpPost]
        public IHttpActionResult ThemTienIch([FromBody]dynamic dynamic)

        {
            IHttpActionResult respon = Ok();
            TienIch tienIch = JsonConvert.DeserializeObject<TienIch>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
               respon = Ok(quanLy.ThemTienIch(tienIch));
                return respon;
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatTienIch([FromBody]dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            TienIch tienIch = JsonConvert.DeserializeObject<TienIch>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.CapNhatTienIch(tienIch));
                return respon;
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaTienIch([FromUri]int id)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                respon = Ok(quanLy.XoaTienIch(id));
                return respon;
            }
        }
        #endregion
    }
}
