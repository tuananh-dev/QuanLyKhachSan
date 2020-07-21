using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.KhachHangBusiness;

namespace QLKSProject.Controllers.KhachHang
{
    public class KhachHangController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LayDanhSachKhachHangTheoMaDoan([FromUri] string maDoan)
        {
            IHttpActionResult respone = Ok();
            using(KhachHangBusiness khachHangBusiness = new KhachHangBusiness())
            {
                respone = Ok(khachHangBusiness.LayDanhSachKhachHangTheoMaDoan(maDoan));
            }
            return respone;
        }
    }
}
