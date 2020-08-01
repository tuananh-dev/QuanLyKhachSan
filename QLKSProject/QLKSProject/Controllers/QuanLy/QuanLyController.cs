﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using QLKSProject.Business.QuanLy;
using QLKSProject.Models.DTO;

namespace QLKSProject.Controllers.QuanLy
{
    [Authorize(Roles = "ql")]
    public class QuanLyController : ApiController
    {
        #region API xu ly TaiKhoan
        [HttpGet]
        public IHttpActionResult LayDanhSachTaiKhoan()
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayDanhSachTaiKhoan());
            }
        }
        [HttpGet]
        public IHttpActionResult LayTaiKhoan([FromUri] int id)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayTaiKhoan(id));
            }

        }
        [HttpPost]
        public IHttpActionResult ThemTaiKhoan([FromBody]dynamic dynamic)
        {
            if (dynamic == null)
                return BadRequest();
            UserMasterDTO tk = JsonConvert.DeserializeObject<UserMasterDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.ThemTaiKhoan(tk))
                    return Ok("Thêm tài khoản thành công!");
                else
                    return BadRequest("Thêm tài khoản thất bại!");
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatTaiKhoan([FromBody] dynamic dynamic)
        {
            UserMasterDTO tk = JsonConvert.DeserializeObject<UserMasterDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                string result = quanLy.CapNhatTaiKhoan(tk);
                if (result.Equals("ok"))
                    return Ok("Cập nhật tài khoản thành công!");
                else
                    return BadRequest(result);
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaTaiKhoan([FromUri]int id)
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.XoaTaiKhoan(id))
                    return Ok("Xóa tài khoản thành công!");
                else
                    return BadRequest("Xóa tài khoản thát bại!");
            }
        }
        #endregion
        #region API xu ly Phong
        [HttpGet]
        public IHttpActionResult LayDanhSachPhong()
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayDanhSachPhong());
            }
        }
        [HttpGet]
        public IHttpActionResult LayPhong([FromUri]int id)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayPhong(id));
            }
        }
        [HttpPost]
        public IHttpActionResult ThemPhong([FromBody]dynamic dynamic)
        {
            PhongDTO phong = JsonConvert.DeserializeObject<PhongDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                string result = quanLy.ThemPhong(phong);
                if (result.Equals("ok"))
                    return Ok("Thêm phòng thành công!");
                else
                    return BadRequest(result);
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatPhong([FromBody] dynamic dynamic)
        {
            PhongDTO phong = JsonConvert.DeserializeObject<PhongDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.CapNhatPhong(phong))
                    return Ok("Cập nhật phòng thành công!");
                else
                    return BadRequest("Cập nhật phòng thất bại!");
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaPhong([FromUri]int id)
        {         
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.XoaPhong(id))
                    return Ok("Xóa phòng thành công!");
                else
                    return BadRequest("Xóa phòng thất bại!");
            }
        }
        [HttpPost]
        public IHttpActionResult TaoDanhSachPhong([FromBody] dynamic dynamic)
        {
            ThemPhongTheoLauDTO themPhongTheoLauDTO = JsonConvert.DeserializeObject<ThemPhongTheoLauDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                string result = quanLy.TaoDanhSachPhong(themPhongTheoLauDTO);
                if (result.Equals("ok"))
                    return Ok("Thêm danh sách phòng thành công!");
                else
                    return BadRequest(result);
            }
        }
        #endregion
        #region API xu ly DichVu
        [HttpGet]
        public IHttpActionResult LayDanhSachDichVu()
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayDanhSachDichVu());
            }
        }

        [HttpGet]
        public IHttpActionResult LayDichVu([FromUri] int id)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayDichVu(id));   
            }
        }
        [HttpPost]
        public IHttpActionResult ThemDichVu([FromBody]dynamic dynamic)
        {
            DichVuDTO dv = JsonConvert.DeserializeObject<DichVuDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.ThemDichVu(dv))
                    return Ok("Thêm dịch vụ thành công!");
                else
                    return BadRequest("Thêm dịch vụ thất bại!");
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatDichVu([FromBody]dynamic dynamic)
        {
            IHttpActionResult respon = Ok();
            DichVuDTO dv = JsonConvert.DeserializeObject<DichVuDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.CapNhatDichVu(dv))
                    return Ok("Cập nhật dịch vụ thành công!");
                else
                    return BadRequest("Cập nhật dịch vụ thất bại!");
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaDichVu([FromUri]int id)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.XoaDichVu(id))
                    return Ok("Xóa dịch vụ thành công!");
                else
                    return BadRequest("Xóa dịch vụ thất bại!");
            }
        }
        #endregion
        #region API xu ly TienIch
        [HttpGet]
        public IHttpActionResult LayDanhSachTienIch()
        {
            IHttpActionResult respon = Ok();
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayDanhSachTienIch());
            }
        }
        [HttpGet]
        public IHttpActionResult LayTienIch([FromUri]int id)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                return Ok(quanLy.LayTienIch(id));
            }
        }

        [HttpPost]
        public IHttpActionResult ThemTienIch([FromBody]dynamic dynamic)

        {
            TienIchDTO tienIch = JsonConvert.DeserializeObject<TienIchDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.ThemTienIch(tienIch))
                    return Ok("Thêm tiện ích thành công!");
                else
                    return BadRequest("Thêm tiện ích thất bại!");
            }
        }
        [HttpPut]
        public IHttpActionResult CapNhatTienIch([FromBody]dynamic dynamic)
        {
            TienIchDTO tienIch = JsonConvert.DeserializeObject<TienIchDTO>(dynamic.ToString());
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.CapNhatTienIch(tienIch))
                    return Ok("Cập nhật tiện ích thành công!");
                else
                    return BadRequest("Cập nhật tiện ích thất bại!");
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaTienIch([FromUri]int id)
        {
            using (QuanLyBusiness quanLy = new QuanLyBusiness())
            {
                if (quanLy.XoaTienIch(id))
                    return Ok("Xóa tiện ích thành công!");
                else
                    return BadRequest("Xóa tiện ích thất bại");
            }
        }
        #endregion
        #region Bao Cao Thong Ke
        [HttpPost]
        public IHttpActionResult XuatBaoCaoThongKeTheoThang(dynamic dynamic)
        {
            int thang = int.Parse(dynamic.thang.ToString());
            int nam = int.Parse(dynamic.nam.ToString());
            using(QuanLyBusiness quanLyBusiness = new QuanLyBusiness())
            {
                return Ok(quanLyBusiness.BaoCaoThongKeTheoThang(thang, nam));
            }   
        }
        [HttpPost]
        public IHttpActionResult XuatBaoCaoThongKeTheoQuy(dynamic dynamic)
        {
            if(dynamic.quy == null)
            {
                return BadRequest("Không có dữ liệu truyền vào!");
            }
            int quy = int.Parse(dynamic.quy.ToString());
            int nam = int.Parse(dynamic.nam.ToString());
            using (QuanLyBusiness quanLyBusiness = new QuanLyBusiness())
            {
                return Ok(quanLyBusiness.BaoCaoThongKeTheoQuy(quy, nam));
            }
        }
        [HttpPost]
        public IHttpActionResult SoSanhSoSanhThongKeTheoThang(dynamic dynamic)
        {
            int thang = int.Parse(dynamic.thang.ToString());
            int nam = int.Parse(dynamic.nam.ToString());
            using (QuanLyBusiness quanLyBusiness = new QuanLyBusiness())
            {
                return Ok(quanLyBusiness.SoSanhThongKeTheoThang(thang, nam));
            }
        }
        [HttpPost]
        public IHttpActionResult SoSanhSoSanhThongKeTheoQuy(dynamic dynamic)
        {
            int quy = int.Parse(dynamic.quy.ToString());
            int nam = int.Parse(dynamic.nam.ToString());
            using (QuanLyBusiness quanLyBusiness = new QuanLyBusiness())
            {
                return Ok(quanLyBusiness.SoSanhThongKeTheoQuy(quy, nam));
            }
        }
        #endregion
    }
}
