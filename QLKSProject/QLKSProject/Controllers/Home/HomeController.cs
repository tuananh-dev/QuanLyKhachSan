using QLKSProject.Business.Home;
using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.UI;
using System.Xml;

namespace QLKSProject.Controllers.Home
{
    public class HomeController : ApiController

    {

        string TenTaiKhoan = Thread.CurrentPrincipal.Identity.Name;




        [Authorize]


        //[HttpPost]
        //public IHttpActionResult KiemTraTaiKhoan(string TenTaiKhoan, string MatKhau)
        //{
        //	IHttpActionResult respone = Ok();
        //	using (HomeBusiness homeBusiness = new HomeBusiness())
        //	{
        //		respone = Ok(homeBusiness.KiemTraTaiKhoan());
        //              return respone;
        //	}
        //}
  //      [HttpPost]
  //      public IHttpActionResult KiemTraTaiKhoan(TaiKhoan taikhoan)
		//{
  //          IHttpActionResult respone = Ok(taikhoan);
  //          using (HomeBusiness homeBusiness = new HomeBusiness())
  //              respone = Ok(homeBusiness.KiemTraTaiKhoan(taikhoan));
  //          return respone;
		//}

        public IHttpActionResult TestDuLieuTruyenXuong(dynamic dynamic)
        {
            IHttpActionResult respone = Ok(dynamic);

            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                respone = Ok(homeBusiness.TestDuLieuTruyenXuong(dynamic));
                return respone;
             }
        }

        public IHttpActionResult LayFileDanhSachKhachHang(dynamic dynamic)
        {
            IHttpActionResult respone = Ok();
            if(dynamic == null)
            {
                return respone = Ok(false);
            }
            try
            {
                string tenDoan = dynamic.TenDoan.ToString();
                string tenTruongDoan = dynamic.TenTruongDoan.ToString();
                DateTime thoiGianNhan = dynamic.ThoiGianNhan;
                DateTime thoiGianTra = dynamic.ThoiGianTra;
                string fileDSKhachHang = dynamic.Files.ToString();
                using (HomeBusiness homeBusiness = new HomeBusiness())
                {
                    respone = Ok(homeBusiness.LayFileDanhSachKhachHang(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, fileDSKhachHang));
                }
            }
            catch (Exception)
            {
                respone = Ok(false);
            }
           
            return respone;
        }
        //[HttpPost]
        //public static bool KiemTraTaiKhoan(string TenTaiKhoan, string MatKhau)
        //{
        //    using (HomeBusiness entities = new HomeBusiness())
        //    {
        //        Models.Entities.TaiKhoan tk = new Models.Entities.TaiKhoan();
        //        return Models.Entities.TaiKhoans.Any(user => user.TenTaiKhoan.Equals(TenTaiKhoan, StringComparison.OrdinalIgnoreCase) && user.MatKhau == MatKhau);
               
        //    }
        //}
    }
}