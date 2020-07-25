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
            using (NhanVienBusiness nhanvien = new NhanVienBusiness())
            {
                return Ok(nhanvien.LayDanhSachDoan());
            }
        }    
        [HttpGet]
        public IHttpActionResult DatPhongChoTungDoan([FromUri] string id)
        {
            string result = "";
            using(NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                result = nhanVienBusiness.DatPhong(id);
            }
            if (result.Equals("ok"))
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet]
        public IHttpActionResult DatPhongChoNhieuDoan()
        {
            using(NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                return Ok(nhanVienBusiness.DatPhongChoNhieuDoan());
            }           
        }
        [HttpGet]
        public IHttpActionResult LayDanhSachKhachHangTheoMaDoan([FromUri] string id)
        {
            using (NhanVienBusiness khachHangBusiness = new NhanVienBusiness())
            {
                return Ok(khachHangBusiness.LayDanhSachKhachHangTheoMaDoan(id));
            }
        }
        [HttpGet]
        public IHttpActionResult LayDanhSachPhong()
        {
            using (NhanVienBusiness quanLy = new NhanVienBusiness())
            {
                return Ok(quanLy.LayDanhSachPhong());
            }
        }
        [HttpPost]
        public IHttpActionResult DatPhongThuNghiem([FromBody]dynamic dynamic)
        {
            if(dynamic == null)
            {
                return BadRequest();
            }
            List<KhachHangDTO> lstKhachHang = JsonConvert.DeserializeObject<List<KhachHangDTO>>(dynamic.ToString());
            using(NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                string result = nhanVienBusiness.DatPhongThuNghiem(lstKhachHang);
                if (result.Equals("ok"))
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
        [HttpGet]
        public IHttpActionResult LayDanhSachDoanDatPhongThanhCong()
        {
            using(NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                return Ok(nhanVienBusiness.LayDanhSachDoanTheoTrangThaiDatPhong(1));
            }
        }
        [HttpGet]
        public IHttpActionResult LayDanhSachDoanDatPhongThatBai()
        {
            using (NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                return Ok(nhanVienBusiness.LayDanhSachDoanTheoTrangThaiDatPhong(-1));
            }
        }
    }
}
