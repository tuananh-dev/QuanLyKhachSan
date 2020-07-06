using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business.NhanVien;
using QLKSProject.Models.DTO;


namespace QLKSProject.Controllers.NhanVien
{
    public class NhanVienController : ApiController
    {
        [HttpPost]
        public IHttpActionResult LayDanhSachDoan()
        {

            IHttpActionResult respon = Ok();
            using (NhanVienBusiness nhanvien = new NhanVienBusiness())
            {
                if (nhanvien.LayDanhSachDoan() == null)
                    respon = Ok("Không có dữ liệu");
                else
                    respon = Ok(nhanvien.LayDanhSachDoan());
                

            }
            return respon;
        }
        [HttpPost]
        public IHttpActionResult LayDanhSachDatPhongThanhCong()
        {
            IHttpActionResult respon = Ok();
            using (NhanVienBusiness datphongthanhcong = new NhanVienBusiness())
            {

                respon = Ok(datphongthanhcong.LayDanhSachDatPhongThanhCong());
                      
            }
            return respon;
        }
        
        [HttpPost]
        public IHttpActionResult LayDanhSachDatPhongThatBai()
        {
            IHttpActionResult respon = Ok();
            using (NhanVienBusiness datPhongThatBai = new NhanVienBusiness())
            {
                if (datPhongThatBai.LayDanhSachDatPhongThatBai() != null)
                    respon = Ok(datPhongThatBai.LayDanhSachDatPhongThatBai());
                else
                    respon = Ok("Không có dữ liệu");
            }
            return respon;

        }        

    }
}
