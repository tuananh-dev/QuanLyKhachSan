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
        public IHttpActionResult DatPhong([FromUri] string id)
        {
            string result = "";
            using(NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                result = nhanVienBusiness.DatPhong(id);
            }
            if (result.Equals("ok"))
                return Ok();
            else
                return BadRequest(result);
        }
   
    }
}
