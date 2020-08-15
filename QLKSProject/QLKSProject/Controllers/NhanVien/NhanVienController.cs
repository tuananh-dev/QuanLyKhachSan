using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using QLKSProject.Business.NhanVien;
using QLKSProject.Models.DTO;


namespace QLKSProject.Controllers.NhanVien
{
    [Authorize(Roles = "nv")]
    public class NhanVienController : ApiController
    {
        #region Danh Sach Doan Dat Phong
        [HttpGet]
        public IHttpActionResult LayDanhSachDoan()
        {
            using (NhanVienBusiness nhanvien = new NhanVienBusiness())
            {
                return Ok(nhanvien.LayDanhSachDoanTheoTrangThaiDatPhong(0));
            }
        }
        [HttpGet]
        public IHttpActionResult DatPhongChoTungDoan([FromUri] string id)
        {
            string result = "";
            using (NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                result = nhanVienBusiness.DatPhongChoMotDoan(id);
                if (result.Equals("ok"))
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
        [HttpGet]
        public IHttpActionResult DatPhongChoNhieuDoan()
        {
            using (NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                return Ok(nhanVienBusiness.DatPHongNhieuDoanKhachHang());
            }
        }
        #endregion

        #region Danh Sach Doan Dat Phong That Bai
        [HttpGet]
        public IHttpActionResult LayDanhSachKhachHangTheoMaDoan([FromUri] string id)
        {
            using (NhanVienBusiness khachHangBusiness = new NhanVienBusiness())
            {
                return Ok(khachHangBusiness.LayDanhSachKhachHangTheoMaDoan(id));
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
        [HttpPost]
        public IHttpActionResult DatPhongThuNghiem([FromBody]dynamic dynamic)
        {
            if (dynamic == null)
            {
                return BadRequest();
            }
            List<KhachHangDTO> lstKhachHang = JsonConvert.DeserializeObject<List<KhachHangDTO>>(dynamic.ToString());
            using (NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                string result = nhanVienBusiness.DatPhongThuNghiem(lstKhachHang);
                if (result.Equals("ok"))
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaDoan([FromUri]string id)
        {
            using (NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                return Ok(nhanVienBusiness.XoaDoan(id));
            }
        }
        #endregion

        #region Danh Sach Dat Phong Thanh Cong
        [HttpGet]
        public IHttpActionResult LayDanhSachDoanDatPhongThanhCong()
        {
            using (NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                return Ok(nhanVienBusiness.LayDanhSachDoanTheoTrangThaiDatPhong(1));
            }
        }
        #endregion

        #region Quan Ly Phong, nhan phong, tra phong
        [HttpGet]
        public IHttpActionResult LayDanhSachPhong()
        {
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                return Ok(nhanVien.LayDanhSachPhong());
            }
        }
        [HttpPost]
        public IHttpActionResult LayDanhSachPhongTheoDieuKien([FromBody]dynamic dynamic)
        {
            if (dynamic == null)
                return BadRequest();
            ThoiGianDatPhongDTO thoiGianDatPhong = JsonConvert.DeserializeObject<ThoiGianDatPhongDTO>(dynamic.ToString());
            using (NhanVienBusiness nhanVienBusiness = new NhanVienBusiness())
            {
                return Ok(nhanVienBusiness.LayDanhSachPhongTheoDieuKien(thoiGianDatPhong.NgayNhan, thoiGianDatPhong.NgayTra));
            }
        }
        [HttpPost]
        public IHttpActionResult KhachHangNhanPhong([FromBody]dynamic dynamic)
        {
            KhachHangNhanPhongDTO khachHang = JsonConvert.DeserializeObject<KhachHangNhanPhongDTO>(dynamic.ToString());
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                string status = nhanVien.KhachHangNhanPhong(khachHang.IDPhong, khachHang.HoVaTen, khachHang.CMND);
                if (status.Equals("ok"))
                    return Ok("Nhận phòng thành công!");
                else
                    return BadRequest(status);
            }
        }
        [HttpPost]
        public IHttpActionResult KhachHangTraPhong([FromBody]string cmnd)
        {
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                string status = nhanVien.KhachHangTraPhong(cmnd);
                if (status.Equals("ok"))
                    return Ok("Trả phòng thành công!");
                else
                    return BadRequest(status);
            }
        }
        [HttpGet]
        public IHttpActionResult LayDanhSachTenKhachHangChungPhong([FromUri]int id)
        {
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                return Ok(nhanVien.DanhSachKhachHangChungPhong(id));
            }
        }
        [HttpGet]
        public IHttpActionResult DanhSachKhachHangChungPhongDichVuPhong([FromUri]int id)
        {
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                return Ok(nhanVien.DanhSachKhachHangChungPhongDichVuPhong(id));
            }
        }
        [HttpGet]
        public IHttpActionResult LayThongTinChiPhiPhong([FromUri]int id)
        {
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                if (nhanVien.LayThongTinChiPhiPhong(id) == null)
                    return BadRequest("Khách hàng không gọi dịch vụ!");
                else
                    return Ok(nhanVien.LayThongTinChiPhiPhong(id));
            }
        }
        #endregion

        #region Dich Vu Phong
        [HttpGet]
        public IHttpActionResult LayDSLichSuDichVu()
        {
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                return Ok(nhanVien.LayDSLichSuDichVu());
            }
        }
        [HttpPost]
        public IHttpActionResult ThemMoiDichVuPhong([FromBody]dynamic dynamic)
        {
            LichSuDichVuDTO lichSuDichVuDTO = JsonConvert.DeserializeObject<LichSuDichVuDTO>(dynamic.ToString());
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                if (nhanVien.ThemMoiDichVuPhong(lichSuDichVuDTO))
                    return Ok("Thêm mới thành công!!!");
                else
                    return BadRequest("Thêm mới thất bại!!!");
            }
        }
        [HttpDelete]
        public IHttpActionResult XoaDichVuPhong([FromUri]int id)
        {
            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                string status = nhanVien.XoaDichVuPhong(id);
                if (status.Equals("ok"))
                    return Ok("Xóa thành công!");
                else
                    return BadRequest("Xóa thất bại!");
            }
        }
        [HttpGet]
        public IHttpActionResult LayDanhSachDichVu()
        {

            using (NhanVienBusiness nhanVien = new NhanVienBusiness())
            {
                return Ok(nhanVien.LayDanhSachDichVu());
            }
        }
        #endregion
    }
}
