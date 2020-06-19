using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Models.Entities;
using QLKSProject.Business.NhanVien;

namespace QLKSProject.Controllers.NhanVien
{
    public class NhanVienController : ApiController
    {
        [HttpPost]
        public List<DanhSachFileGui> LayDanhSachFile()
        {
            using(NhanVienBusiness nv = new NhanVienBusiness())
            {
                return nv.LayDanhSachFileGui();
            }

            
        }
    }
}
