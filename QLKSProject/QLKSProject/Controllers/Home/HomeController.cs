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
            if (dynamic == null)
            {
                return BadRequest();
            }

            string tenDoan = dynamic.TenDoan.ToString();
            string tenTruongDoan = dynamic.TenTruongDoan.ToString();
            DateTime thoiGianNhan = dynamic.ThoiGianNhan;
            DateTime thoiGianTra = dynamic.ThoiGianTra;
            string fileDSKhachHang = dynamic.Files.ToString();

            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                string result = homeBusiness.LayFileDanhSachKhachHang(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, fileDSKhachHang);
                if (result.Equals("ok"))
                    return Ok("Lưu file thành công !"); 
                else
                    return BadRequest(result);

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
            using (HomeBusiness homeBusiness = new HomeBusiness())
            {    
                if (homeBusiness.CheckTaiKhoan(maDoan))
                    return BadRequest();
                else
                    return Ok(userRoles + "-" + fullName + "-" + maDoan);
            }
            
        }
    }
}