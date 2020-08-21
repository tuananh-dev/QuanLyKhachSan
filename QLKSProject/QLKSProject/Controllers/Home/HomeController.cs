using Newtonsoft.Json;
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
            FileKhachHangDTO file = JsonConvert.DeserializeObject<FileKhachHangDTO>(dynamic.ToString());
            if (file == null)
            {
                return BadRequest();
            }

            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                string result = homeBusiness.LayFileDanhSachKhachHang(file.TenDoan, file.TenTruongDoan, file.ThoiGianNhan, file.ThoiGianTra, file.Files);
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
            return Ok(userRoles + "-" + fullName + "-" + maDoan);

        }
    }
}