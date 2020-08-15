using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLKSProject.Controllers.Home;

namespace QLKSProjectTest.Test
{
    [TestClass]
    public class Home_UnitTest
    {
        Data_Test data_test;
        HomeController controller;
        public Home_UnitTest()
        {
            data_test = new Data_Test();
            controller = new HomeController();

        }
        [TestMethod]
        public void LayFileDanhSachKhachHang_TestStatusResponse()
        {
            var action_result = controller.LayFileDanhSachKhachHang("");
            //result
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var actual_result3 = action_result as BadRequestResult;
            var expected_result1 = "Lưu file thành công !";
            var expected_restul2 = data_test.ThongBaoLoi();
            var expected_restul3 = action_result as BadRequestResult;
            //assert
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (Exception)
            {
                try
                {
                    Assert.AreEqual(expected_restul2, actual_result2.Message);
                }
                catch (Exception)
                {
                    Assert.AreEqual(expected_restul3, actual_result3);
                }     
            }
        }

    }
}
