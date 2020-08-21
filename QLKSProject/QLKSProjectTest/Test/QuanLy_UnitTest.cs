using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLKSProject.Models.DTO;
using QLKSProject.Controllers.QuanLy;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using QLKSProjectTest;

namespace QLKSProjectTest.Test
{
    [TestClass]
    public class QuanLy_UnitTest
    {
        private Data_Test data_test;
        private QuanLyController controller;
        public QuanLy_UnitTest()
        {
            data_test = new Data_Test();
            controller = new QuanLyController();
        }

        #region TaiKhoan 
        [TestMethod]
        public void XoaTaiKhoan_TestStatusResponse()
        {
            // Act
            IHttpActionResult actionResult = controller.XoaTaiKhoan(137);
            var actual_result = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            try
            {
                Assert.AreEqual("Xóa tài khoản thành công!", actual_result.Content);
            }
            catch (System.Exception)
            {
                var actual_result2 = actionResult as BadRequestErrorMessageResult;
                Assert.AreEqual("Thêm tài khoản thất bại!", actual_result2.Message);
            }

        }
        [TestMethod]
        public void ThemTaiKhoan_TestStatusResponse()
        {
            var newAccount = data_test.TaiKhoan();
            // Act
            IHttpActionResult actionResult = controller.ThemTaiKhoan(newAccount);
            var actual_result = actionResult as NegotiatedContentResult<string>;

            // Assert
            try
            {
                Assert.AreEqual("Thêm tài khoản thành công!", actual_result.Content);
            }
            catch (System.Exception)
            {
                var actual_result2 = actionResult as BadRequestErrorMessageResult;
                Assert.AreEqual("Thêm tài khoản thất bại!", actual_result2.Message);
            }

        }
        [TestMethod]
        public void LayTaiKhoan_TestStatusResponse()
        {
            //Act
            IHttpActionResult actionResult = controller.LayTaiKhoan(132);
            var actual_result = actionResult as OkNegotiatedContentResult<UserMasterDTO>;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actual_result.Content);
            Assert.AreEqual("anhnguyenduc", actual_result.Content.UserName);
        }
        [TestMethod]
        public void CapNhatTaiKhoan_TestStatusResponse()
        {
            Data_Test data_Test = new Data_Test();
            var newAccount = data_Test.TaiKhoan();
            // Act
            IHttpActionResult actionResult = controller.CapNhatTaiKhoan(newAccount);
            var actual_result = actionResult as OkNegotiatedContentResult<string>;
            // Assert
            try
            {
                Assert.AreEqual("Cập nhật tài khoản thành công!", actual_result.Content);
            }
            catch (System.Exception)
            {

                Assert.IsNotNull(actual_result.Content);
            }
            
        }
        [TestMethod]
        public void LayDanhSachTaiKhoan_TestStatusResponse()
        {
            Data_Test data_Test = new Data_Test();
            var count = data_Test.DemSoLuongTaiKhoan();
            //Act
            IHttpActionResult actionResult = controller.LayDanhSachTaiKhoan();
            var actual_result = actionResult as OkNegotiatedContentResult<List<UserMasterDTO>>;

            //Assert
            Assert.AreEqual(count, actual_result.Content.Count);
        }
        #endregion

        #region Phong
        [TestMethod]
        public void LayDanhSachPhong_TestStatusResponse()
        {
            var actionResult = controller.LayDanhSachPhong();
            //Act
            var actual_result = actionResult as OkNegotiatedContentResult<List<PhongDTO>>;
            var expected_result = data_test.DemSoLuongPhong();
            //Assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void LayPhong_TestStatusResponse()
        {
            var phong = data_test.LayThongTinPhong();
            var actionResult = controller.LayPhong(phong.ID);
            //Act
            var actual_result = actionResult as OkNegotiatedContentResult<PhongDTO>;
            var expected_result = phong.SoPhong;
            //Assert

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(expected_result, actual_result.Content.SoPhong);
        }
        [TestMethod]
        public void ThemPhong_TestStatusResponse()
        {
            var phong = data_test.TaoMoiPhong();
            var action_result = controller.ThemPhong(phong);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expect_result1 = "Thêm phòng thành công!";
            var expect_result2 = "Lỗi phòng đã tồn tại!";
            //Assert
            try
            {
                Assert.AreEqual(expect_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expect_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void CapNhatPhong_TestStatusResponse()
        {
            var phong = data_test.TaoMoiPhong();
            var action_result = controller.CapNhatPhong(phong);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Cập nhật phòng thành công!";
            var expected_result2 = "Cập nhật phòng thất bại!";
            //Assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void XoaPhong_TestStatusResponse()
        {
            var action_result = controller.XoaPhong(7);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Xóa phòng thành công!";
            var expected_result2 = "Xóa phòng thất bại!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        #endregion

        #region Dich Vu
        [TestMethod]
        public void LayDanhSachDichVu_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachDichVu();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<DichVuDTO>>;
            var count = data_test.SoLuongDichVu();
            //assert
            Assert.AreEqual(count, actual_result.Content.Count);
        }
        [TestMethod]
        public void LayDichVu_TestStatusResponse()
        {
            var dich_vu = data_test.LayThongTinDichVu();
            var action_result = controller.LayDichVu(dich_vu.ID);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<DichVuDTO>;
            var expected_result = dich_vu.TenDichVu;
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.TenDichVu);
        }
        [TestMethod]
        public void ThemDichVu_TestStatusResponse()
        {
            var dich_vu = data_test.TaoMoiDichVu();
            var action_result = controller.ThemDichVu(dich_vu);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Thêm dịch vụ thành công!";
            var expected_result2 = "Thêm dịch vụ thất bại!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }

        }
        [TestMethod]
        public void CapNhatDichVu_TestStatusResponse()
        {
            var dich_vu = data_test.TaoMoiDichVu();
            var action_result = controller.CapNhatDichVu(dich_vu);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Cập nhật dịch vụ thành công!";
            var expected_result2 = "Cập nhật dịch vụ thất bại!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void XoaDichVu_TestStatusResponse()
        {
            var action_result = controller.XoaDichVu(50);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Xóa dịch vụ thành công!";
            var expected_result2 = "Xóa dịch vụ thất bại!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        #endregion

        #region Tien Ich
        [TestMethod]
        public void LayDanhSachTienIch_TestStatusResponse()
        {
            var action_result = controller.LayDanhSachTienIch();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<TienIchDTO>>;
            var expected_result = data_test.SoLuongTienIch();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void LayTienIch_TestStatusResponse()
        {
            var tien_ich = data_test.LayThongTinTienIch();
            var action_result = controller.LayTienIch(tien_ich.ID);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<TienIchDTO>;
            var expected_result = tien_ich.TenTienIch;
            //
            Assert.AreEqual(expected_result, actual_result.Content.TenTienIch);
        }
        [TestMethod]
        public void ThemTienIch_TestStatusResponse()
        {
            var tien_ich = data_test.TaoMoiTienIch();
            var action_result = controller.ThemTienIch(tien_ich);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Thêm tiện ích thành công!";
            var expected_result2 = "Thêm tiện ích thất bại!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void CapNhatTienIch_TestStatusResponse()
        {
            var tien_ich = data_test.TaoMoiTienIch();
            var action_result = controller.CapNhatTienIch(tien_ich);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Cập nhật tiện ích thành công!";
            var expected_result2 = "Cập nhật tiện ích thất bại!";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        [TestMethod]
        public void XoaTienIch_TestStatusResponse()
        {
            var action_result = controller.XoaTienIch(42);
            //act
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Xóa tiện ích thành công!";
            var expected_result2 = "Xóa tiện ích thất bại";
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }
        #endregion

        #region Thong Ke
        [TestMethod]
        public void XuatBaoCaoThongKeTheoThang_TestStatusResponse()
        {
            string date = "{\"thang\":\"3\",\"nam\":\"2020\"}";
            var action_result = controller.XuatBaoCaoThongKeTheoThang(date);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<ThongKeTheoThangDTO>>;
            var expected_result = data_test.SoLuongDichVu() + 1;
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void XuatBaoCaoThongKeTheoQuy_TestStatusResponse()
        {
            string date = "{\"quy\":\"3\",\"nam\":\"2020\"}";
            var action_result = controller.XuatBaoCaoThongKeTheoQuy(date);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<ThongKeTheoQuyDTO>>;
            var expected_result = data_test.SoLuongDichVu() + 1;
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void SoSanhThongKeTheoThang_TestStatusResponse()
        {
            var data = data_test.SoSanhThongKeTheoThang(9, 2020);
            string date = "{\"thang\":\"9\",\"nam\":\"2020\"}";
            var action_result = controller.SoSanhSoSanhThongKeTheoThang(date);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<SoSanhThongKeDTO>;
            var expected_result1 = data.TienDichVu;
            var expected_result2 = data.TienThuePhong;
            //assert
            Assert.AreEqual(expected_result1, actual_result.Content.TienDichVu);
            Assert.AreEqual(expected_result2, actual_result.Content.TienThuePhong);
        }
        [TestMethod]
        public void SoSanhThongKeTheoQuy_TestStatusResponse()
        {
            string quy = "{\"quy\":\"3\",\"nam\":\"2020\"}";
            var data = data_test.SoSanhThongKeTheoQuy(3, 2020);
            var action_result = controller.SoSanhSoSanhThongKeTheoQuy(quy);
            //act
            var actual_result = action_result as OkNegotiatedContentResult<SoSanhThongKeDTO>;
            var expected_result1 = data.TienDichVu;
            var expected_result2 = data.TienThuePhong;
            //assert
            Assert.AreEqual(expected_result1, actual_result.Content.TienDichVu);
            Assert.AreEqual(expected_result2, actual_result.Content.TienThuePhong);
        }
        #endregion
    }
}
