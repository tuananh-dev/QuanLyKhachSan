﻿using System;
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
        public bool LayDanhSachKhachHang(KhachHang dsKhachHang)
        {
            using (HomeBusiness homeBusiness = new HomeBusiness())
            {
                
                return homeBusiness.LuuDuLieuXuongCSDL(dsKhachHang);
            }

               
        }
    }
}
