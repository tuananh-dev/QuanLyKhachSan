using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Models;
using QLKSProject.Business.Home;

namespace QLKSProject.Controllers.Home
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public bool LayFileKhachHangGui(FileKhachHang fileKhachHang)
        {
            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                
                return homeBusiness.LuuDuLieuXuongCSDL(fileKhachHang);
            }       
        }
        [HttpGet]
        public List<Models.Entities.Doan> LayDanhSachDoan()
        {
           using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                return homeBusiness.LayDanhSachDoan();
            }
        }
        [HttpGet]
        public List<KhachHang> LayDanhSachKhachHang()
        {
            using (HomeBusiness homeBusiness = new HomeBusiness())
            {

				return homeBusiness.LayDanhSachKhachHang();
            }
        }
    }
}
