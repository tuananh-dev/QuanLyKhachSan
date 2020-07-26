using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.KhachHangBusiness;

namespace QLKSProject.Controllers.KhachHang
{
    [Authorize(Roles = "kh")]
    public class KhachHangController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LayDanhSachKhachHangTheoMaDoan([FromUri] string id)
        {
            using(KhachHangBusiness khachHangBusiness = new KhachHangBusiness())
            {
                return Ok(khachHangBusiness.LayDanhSachKhachHangTheoMaDoan(id));
            }
        }
        [HttpGet]
        public IHttpActionResult XacNhanDatPhong([FromUri]string id)
        {
            using (KhachHangBusiness khachHangBusiness = new KhachHangBusiness())
            {
                bool result = khachHangBusiness.XacNhanDatPhong(id);
                if (result)
                    return Ok("Xác nhận đặt phòng thành công!");
                else
                    return BadRequest("Xác nhận đặt phòng thất bại!");
            }
        }
    }
}
