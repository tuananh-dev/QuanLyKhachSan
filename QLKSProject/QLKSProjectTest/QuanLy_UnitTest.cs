using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLKSProject.Models.DTO;

namespace QLKSProject_UnitTest
{
    [TestClass]
    public class QuanLy_UnitTest
    {
        #region TaiKhoan 
        [TestMethod]
        public void XoaTaiKhoanReturnOK()
        {
            var controller = new QLKSProject.Controllers.QuanLy.QuanLyController();
            // Act
            IHttpActionResult actionResult = controller.XoaTaiKhoan(137);
            var actual_result = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            Assert.AreEqual("Xóa tài khoản thành công!", actual_result.Content);
        }
        [TestMethod]
        public void ThemTaiKhoanReturnOk()
        {
            Data_Test data_Test = new Data_Test();
            var newAccount = data_Test.TaiKhoan();
            var controller = new QLKSProject.Controllers.QuanLy.QuanLyController();
            // Act
            IHttpActionResult actionResult = controller.ThemTaiKhoan(newAccount);
            var actual_result = actionResult as OkNegotiatedContentResult<string>;

            // Assert
            try
            {
                Assert.AreEqual("Thêm tài khoản thành công!", actual_result.Content);
            }
            catch (System.Exception)
            {
                Assert.AreEqual("Thêm tài khoản thất bại!", actual_result.Content);
            }
           
        }
        [TestMethod]
        public void LayTaiKhoan()
        {
            Data_Test data_Test = new Data_Test();
            var taiKhoan = data_Test.TaiKhoanDuocLayMau();
            var controller = new QLKSProject.Controllers.QuanLy.QuanLyController();
            //Act
            IHttpActionResult actionResult = controller.LayTaiKhoan(132);
            var actual_result = actionResult as OkNegotiatedContentResult<UserMasterDTO>;

            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actual_result.Content);
            Assert.AreEqual("anhnguyenduc", actual_result.Content.UserName);
        }
        [TestMethod]
        public void CapNhatTaiKhoanReturnOK()
        {
            Data_Test data_Test = new Data_Test();
            var newAccount = data_Test.TaiKhoan();
            var controller = new QLKSProject.Controllers.QuanLy.QuanLyController();
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
            var controller = new QLKSProject.Controllers.QuanLy.QuanLyController();
            var data_test = new Data_Test();
            var count = data_Test.DemSoLuongTaiKhoan();
            //Act
            IHttpActionResult actionResult = controller.LayDanhSachTaiKhoan();
            var actual_result = actionResult as OkNegotiatedContentResult<List<UserMasterDTO>>;

            //Assert
            Assert.AreEqual(count, actual_result.Content.Count);
        }
        #endregion

    }
}
