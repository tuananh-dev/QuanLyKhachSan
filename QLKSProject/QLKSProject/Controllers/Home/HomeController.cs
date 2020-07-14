using QLKSProject.Business.Home;
using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace QLKSProject.Controllers.Home
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public IHttpActionResult LayFileDanhSachKhachHang(List<FileKhachHang> lstfileKhachHang)
        {
            IHttpActionResult respone = Ok(lstfileKhachHang);
            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                respone = Ok(homeBusiness.LayFileDanhSachKhachHang(lstfileKhachHang));
                return respone;
            }
        }

        public IHttpActionResult TestDuLieuTruyenXuong(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();

            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                respon = Ok(homeBusiness.TestDuLieuTruyenXuong(dynamic));
            }
            return respon;
        }
    }
}