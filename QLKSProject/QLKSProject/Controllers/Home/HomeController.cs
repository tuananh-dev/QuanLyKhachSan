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
        [HttpPost]
        public IHttpActionResult KiemTraTaiKhoan (TaiKhoan taiKhoan)
		{
            IHttpActionResult respone = Ok(taiKhoan);
            using (HomeBusiness homeBusiness = new HomeBusiness())
			{
                respone = Ok(homeBusiness.KiemTraTaiKhoan(taiKhoan));
                return respone;
			}
		}


        [HttpPost]
        public IHttpActionResult TestDuLieuTruyenXuong(dynamic dynamic)
        {
            IHttpActionResult respone = Ok(dynamic);

            using(HomeBusiness homeBusiness = new HomeBusiness())
            {
                respone = Ok(homeBusiness.TestDuLieuTruyenXuong(dynamic));
                return respone;
             }
        }


    }
}