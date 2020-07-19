using QLKSProject.Business.Home;
using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin;
using System.Web.Http.Results;
using Owin;

[assembly: OwinStartup(typeof(TokenAuthenticationInWebAPI.App_Start_Startup))]

namespace QLKSProject.Controllers.Home
{
    [Authorize]
    public class HomeController : ApiController
    {

        [HttpPost]
        public IHttpActionResult KiemTraTaiKhoan(TaiKhoan taiKhoan)
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

            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                respone = Ok(homeBusiness.TestDuLieuTruyenXuong(dynamic));
                return respone;
             }
        }
        public void Configuration (IAppBuilder app)
		{

		}

    }
}