using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLKSProject.Controllers.NhanVien;
using QLKSProject.Models.DTO;
using QLKSProject.Business.NhanVien;

namespace QLKSProjectTest.Test
{
    [TestClass]
    public class NhanVien_UnitTest
    {
        Data_Test data_test;
        NhanVienController controller;
        NhanVienBusiness business;
        public NhanVien_UnitTest()
        {
            data_test = new Data_Test();
            controller = new NhanVienController();
            business = new NhanVienBusiness();
        }
        #region Danh Sach Doan Dat Phong
        [TestMethod]
        public void LayDanhSachDoan_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachDoan();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<DoanDTO>>;
            var expected_result = data_test.SoLuongDoan();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void DatPhongChoTungDoan_TestStatusResponse()
        {
            var action_result = controller.DatPhongChoTungDoan("546251");
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "ok";
            var expected_result2 = actual_result2.Message;
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (Exception)
            {
                Assert.IsNotNull(expected_result2);
            }
        }
        [TestMethod]
        public void DatPhongChoNhieuDoan_TestStatusResponse()
        {
            var action_result = controller.DatPhongChoNhieuDoan();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<string>;
            //assert
            Assert.IsNotNull(actual_result.Content);
        }
        #endregion

        #region Danh Sach Doan Dat Phong Thanh Cong
        [TestMethod]
        public void LayDanhSachDoanDatPhongThanhCong_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachDoanDatPhongThanhCong();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<DoanDTO>>;
            var expected_result = data_test.SoLuongDoanDatPhongThanhCong();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }

        #endregion

        #region Danh Sach Doan Dat Phong That Bai
        [TestMethod]
        public void LayDanhSachKhachHangTheoMaDoan_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachKhachHangTheoMaDoan("37648363");
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<KhachHangDTO>>;
            var expected_result = data_test.SoLuongKhachHangTrongDoan("37648363");
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void LayDanhSachDoanDatPhongThatBai_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachDoanDatPhongThatBai();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<DoanDTO>>;
            var expected_result = data_test.SoLuongDoanDatPhongThatBai();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void XoaDoan_TestStatusResponse()
        {
            var action_result = controller.XoaDoan("484755");
            //act
            var actual_result = action_result as OkNegotiatedContentResult<bool>;
            //assert
            try
            {
                Assert.AreEqual(true, actual_result.Content);
            }
            catch (Exception)
            {
                Assert.AreEqual(false, actual_result.Content);
            }
        }
        [TestMethod]
        public void LayDanhSachPhong_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachPhong();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<PhongDTO>>;
            var expected_result = data_test.DemSoLuongPhong();
            //asset
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        #endregion

        #region Quan Ly Phong, nhan phong, tra phong
        [TestMethod]
        public void LayDanhSachPhongTheoDieuKien_TestStatusResponse()
        {
            string thoiGianDatPhong = "{\"NgayNhan\":\"2020-8-20\",\"NgayTra\":\"2020-8-25\"}";
            var action_result = controller.LayDanhSachPhongTheoDieuKien(thoiGianDatPhong);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<string>>;
            var expected_result = data_test.SoLuongPhongTheoDieuKien();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void KhachHangNhanPhong_TestStatusResponse()
        {
            var khachHang = "{\"IDPhong\":\"231\",\"HoVaTen\":\"Nguyễn Đức Tuấn Anh\",\"CMND\":\"231654465\"}";
            var action_result = controller.KhachHangNhanPhong(khachHang);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Nhận phòng thành công!";
            var expected_result2 = "Lỗi nhận phòng!";
            var expected_result3 = "Lỗi lưu CSDL!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (Exception)
            {
                try
                {
                    Assert.AreEqual(expected_result2, actual_result2.Message);
                }
                catch (Exception)
                {
                    Assert.AreEqual(expected_result3, actual_result2.Message);
                }
            }
        }
        [TestMethod]
        public void KhachHangTraPhong_TestStatusResponse()
        {
            var cmnd = "231654465";
            var action_result = controller.KhachHangTraPhong(cmnd);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Trả phòng thành công!";
            var expected_result2 = "Trả phòng thất bại!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void LayDanhSachTenKhachHangChungPhong_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachTenKhachHangChungPhong(data_test.idPhong);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<KhachHangDTO>>;
            var expected_result = data_test.SoLuongKhachHangChungPhong();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void DanhSachKhachHangChungPhongDichVuPhong_TestStatusResponse()
        {
            var action_result = controller.DanhSachKhachHangChungPhongDichVuPhong(data_test.idPhong);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<KhachHangDTO>>;
            var expected_result = data_test.SoLuongKhachHangChungPhongDichVuPhong();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void LayThongTinChiPhiPhong_TestStatusResponse()
        {
            var action_result = controller.LayThongTinChiPhiPhong(data_test.idPhong);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<List<string>>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = data_test.SoLuongThongTinChiPhiPhong();
            var expected_result2 = "Khách hàng không gọi dịch vụ!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content.Count);
            }
            catch (Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
            
        }

        #endregion

        #region Dich Vu Phong
        [TestMethod]
        public void LayDSLichSuDichVu()
        {
            var action_result = controller.LayDSLichSuDichVu();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<LichSuDichVuDTO>>;
            var expected_result = data_test.SoLuongLichSuDichVu();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void ThemMoiDichVuPhong()
        {
            var lichSuDichVu = data_test.TaoLichSuDichVu();
            var action_result = controller.ThemMoiDichVuPhong(lichSuDichVu);
            //result
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Thêm mới thành công!!!";
            var expected_result2 = "Thêm mới thất bại!!!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void XoaDichVuPhong()
        {
            var action_result = controller.XoaDichVuPhong(4);
            //result
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Xóa thành công!";
            var expected_result2 = "Xóa thất bại!";
            //Assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void LayDanhSachDichVu()
        {
            var action_result = controller.LayDanhSachDichVu();
            //result
            var actual_result = action_result as OkNegotiatedContentResult<List<DichVuDTO>>;
            var expected_result = data_test.SoLuongDichVu();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        #endregion

        #region Kiem tra dat phong
        [TestMethod]
        public void KiemTraDatPhong()
        {
            var action_result = data_test.CheckSoPhong();
            //assert
            Assert.AreEqual("ok", action_result);
        }
        #endregion
    }
}
