using QLKSProject.Business.Home;
using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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
            [HttpPost]
            public IHttpActionResult KiemTraTaiKhoan (LoginRQ loginForm)
		    {
            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
				try
				{
                    return Ok(homeBusiness.login(loginForm)); 
                }
				catch (Exception e )
				{

                    return BadRequest(e.Message);
				}
            
            }
		}
           

    }
}