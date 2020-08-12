using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLKSProject.Models.DTO;
using QLKSProject.Controllers.QuanLy;

namespace QLKSProject_UnitTest
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
        public void XoaTaiKhoan()
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
        public void ThemTaiKhoan()
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
        public void LayTaiKhoan()
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
        public void CapNhatTaiKhoan()
        {
            Data_Test data_Test = new Data_Test();
            var newAccount = data_Test.TaiKhoan();
            // Act
            IHttpActionResult actionResult = controller.CapNhatTaiKhoan(newAccount);
            var actual_result = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            Assert.AreEqual("Cập nhật tài khoản thành công!", actual_result.Content);
        }
        [TestMethod]
        public void LayDanhSachTaiKhoan()
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
        public void LayDanhSachPhong()
        {
            var actionResult = controller.LayDanhSachPhong();
            //Act
            var actual_result = actionResult as OkNegotiatedContentResult<List<PhongDTO>>;
            var expected_result = data_test.DemSoLuongPhong();
            //Assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void LayPhong()
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
        public void ThemPhong()
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
        public void CapNhatPhong()
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
        public void XoaPhong()
        {
            var phong = data_test.LayThongTinPhong();
            var action_result = controller.XoaPhong(phong.ID);
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

    }
}
