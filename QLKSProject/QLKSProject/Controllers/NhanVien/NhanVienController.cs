using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.NhanVien;
<<<<<<< HEAD

=======
using QLKSProject.Models.Entities;
>>>>>>> origin/nhatnam
namespace QLKSProject.Controllers.NhanVien
{
    public class NhanVienController : ApiController
    {
<<<<<<< HEAD

=======
        [HttpPost]
        public List<DanhSachFileGui> LayXuongDanhSachFileGui()
        {
            using (NhanVienBusiness nhanvienBusiness = new NhanVienBusiness())
            {
                nhanvienBusiness.LayDanhSachFileGui();
                return null;
            }
        }
>>>>>>> origin/nhatnam
    }
}
