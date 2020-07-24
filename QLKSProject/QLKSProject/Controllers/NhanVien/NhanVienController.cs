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
    }
}
