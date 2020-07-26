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
            if (dynamic == null)
            {
                return BadRequest("Không láy được file khách hàng !!!");
            }
            bool trangThaiLayDanhSach = false;
            string tenDoan = dynamic.TenDoan.ToString();
            string tenTruongDoan = dynamic.TenTruongDoan.ToString();
            DateTime thoiGianNhan = dynamic.ThoiGianNhan;
            DateTime thoiGianTra = dynamic.ThoiGianTra;
            string fileDSKhachHang = dynamic.Files.ToString();

            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                trangThaiLayDanhSach = homeBusiness.LayFileDanhSachKhachHang(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, fileDSKhachHang);
            }
            if (trangThaiLayDanhSach)
                return Ok("Lưu danh sách thành công !!!");
            else
                return BadRequest("Lưu danh sách lỗi !!!");
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