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
        public bool LayFileDanhSachKhachHang(dynamic dynamic)
        {
<<<<<<< HEAD
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
=======
            //IHttpActionResult respone = Ok();
            //if (dynamic == null)
            //{
            //    return respone = Ok(false);
            //}
            //try
            //{
            //    string tenDoan = dynamic.TenDoan.ToString();
            //    string tenTruongDoan = dynamic.TenTruongDoan.ToString();
            //    DateTime thoiGianNhan = dynamic.ThoiGianNhan;
            //    DateTime thoiGianTra = dynamic.ThoiGianTra;
            //    string fileDSKhachHang = dynamic.Files.ToString();
            //    using (HomeBusiness homeBusiness = new HomeBusiness())
            //    {
            //        respone = Ok(homeBusiness.LayFileDanhSachKhachHang(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, fileDSKhachHang));
            //    }

            //}

            //catch (Exception)
            //{
            //    respone = Ok(false);
            //}
            return true;
>>>>>>> 0f476819cdcc92c0f9f689116f1f48660f7255d9
        }

    }
}