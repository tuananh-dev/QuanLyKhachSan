using QLKSProject.Business.QuanLy;
using QLKSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLKSProject.Controllers.QuanLy
{
    public class QuanLyController : ApiController
    {
        [HttpGet]
        public List<TaiKhoan>LayDanhSachTaiKhoan()
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                
                return quanLy.HienThiDanhSach(); ;
            }
        } 
        [HttpPost]
        public bool ThemTaiKhoanVaoDanhSach(TaiKhoan dstaikhoan)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                quanLy.LuuTaiKhoanXuongCSDL(dstaikhoan);
                return true;
            }   
        }

        [HttpPut]
        public bool LayDanhSachSauKhiSua(TaiKhoan dstaikhoan)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                quanLy.SuaTaiKhoan(dstaikhoan);
                return true;
            }
        }
        [HttpDelete]
        public bool LayDanhSachTaiKhoanSauKhiXoa(int id)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                quanLy.XoaTaiKhoan(id);
                return true;
            }


        }

    }
}
