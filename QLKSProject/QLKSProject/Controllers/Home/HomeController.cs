using QLKSProject.Business.Home;
using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace QLKSProject.Controllers.Home
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public IHttpActionResult LayFileDanhSachKhachHang(dynamic dynamic)
        {
            IHttpActionResult respon = Ok(dynamic);
            return respon;
        }

        [HttpPost]
        public IHttpActionResult TestDuLieuTruyenXuong(dynamic dynamic)
        {
            IHttpActionResult respon = Ok();

            using(HomeBusiness homeBusiness = new HomeBusiness())
            {
                respon = Ok(homeBusiness.TestDuLieuTruyenXuong(dynamic));
            }
            return respon;

        }

    }
}
