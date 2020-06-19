using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.NhanVien;
using QLKSProject.Models.Entities;
namespace QLKSProject.Controllers.NhanVien
{
    public class NhanVienController : ApiController
    {
        [HttpPost]
        public List<DanhSachFileGui> LayXuongDanhSachFileGui()
        {
            using (NhanVienBusiness nhanvienBusiness = new NhanVienBusiness())
            {
                nhanvienBusiness.LayDanhSachFileGui();
                return null;
            }
        }
    }
}
