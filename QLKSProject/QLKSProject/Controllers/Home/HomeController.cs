using QLKSProject.Business.Home;
using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Results;

namespace QLKSProject.Controllers.Home
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public IHttpActionResult LayFileDanhSachKhachHang(dynamic dynamic)
        {
            IHttpActionResult respone = Ok();
            if (dynamic == null)
            {
                return respone = BadRequest();
            }

            string tenDoan = dynamic.TenDoan.ToString();
            string tenTruongDoan = dynamic.TenTruongDoan.ToString();
            DateTime thoiGianNhan = dynamic.ThoiGianNhan;
            DateTime thoiGianTra = dynamic.ThoiGianTra;
            string fileDSKhachHang = dynamic.Files.ToString();

            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                if (!homeBusiness.LayFileDanhSachKhachHang(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, fileDSKhachHang))
                    return BadRequest("Lỗi Lưu file !!!");
                else
                    return Ok("Lưu file thành công !");
            }
        }
        [Authorize(Roles = "ad,ql,nv,kh")]
        [HttpGet]
        public IHttpActionResult LayUserRoles()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userRoles = identity.Claims.FirstOrDefault(c => c.Type == "UserRoles").Value;
            var fullName = identity.Claims.FirstOrDefault(c => c.Type == "FullName").Value;
            var maDoan = identity.Claims.FirstOrDefault(c => c.Type == "MaDoan").Value;
            return Ok(userRoles+"-"+fullName+"-"+maDoan);
        }
    }
}