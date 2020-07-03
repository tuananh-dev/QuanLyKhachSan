using QLKSProject.Business.Home;
using QLKSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace QLKSProject.Controllers.Home
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public bool LayFileKhachHangGui(List<FileKhachHang> lstfileKhachHang)
        {
            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                
                return homeBusiness.LayFileKhachHangGui(lstfileKhachHang);
            }       
        }


    }
}
