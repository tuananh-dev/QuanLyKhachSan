using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using QLKSProject.Business.NhanVien;
using QLKSProject.Models.DTO;


namespace QLKSProject.Controllers.NhanVien
{
    public class NhanVienController : ApiController
    {
        [HttpGet]
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
        [HttpGet]
        public IHttpActionResult LayDanhSachDatPhongThanhCong()
        {
            IHttpActionResult respon = Ok();
            using (NhanVienBusiness datphongthanhcong = new NhanVienBusiness())
            {
                if (datphongthanhcong.LayDanhSachDatPhongThanhCong() != null)
                    respon = Ok(datphongthanhcong.LayDanhSachDatPhongThanhCong());
                else
                    respon = Ok("Không có dữ liệu");
            }
            return respon;

        }
        [HttpGet]
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
        [HttpGet]
        public IHttpActionResult DatPhong()
        {
            string maDoan = "1595348277333";
            IHttpActionResult respon = Ok();
            using(NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                respon = Ok(nhanVienBusiness.DatPhong(maDoan));
            }
            return respon;
        }
    }
}
