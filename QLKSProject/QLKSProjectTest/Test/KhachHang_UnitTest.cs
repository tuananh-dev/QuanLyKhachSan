using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLKSProject.Controllers.KhachHang;
using System.Web.Http.Results;
using QLKSProject.Models.DTO;
using System.Collections.Generic;

namespace QLKSProjectTest.Test
{
    [TestClass]
    public class KhachHang_UnitTest
    {
        Data_Test data_test;
        KhachHangController controller;

        public KhachHang_UnitTest()
        {
            data_test = new Data_Test();
            controller = new KhachHangController();
        }
        [TestMethod]
        public void LayDanhSachKhachHangTheoMaDoan_TestStatusResponse()
        {
            string madoan = "1597429050475";
            var action_result = controller.LayDanhSachKhachHangTheoMaDoan(madoan);
            //
            var actual_result = action_result as OkNegotiatedContentResult<List<KhachHangDTO>>;
            var expected_result = data_test.SoLuongKhachHangTrongDoan(madoan);
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void XacNhanDatPhong_TestStatusResponse()
        {
            string madoan = "1597429050475";
            var action_result = controller.XacNhanDatPhong(madoan);
            //
            var actual_result1 = action_result as OkNegotiatedContentResult<string>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Xác nhận đặt phòng thành công!";
            var expected_result2 = "Xác nhận đặt phòng thất bại!";
            //assert1
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
        public void HuyDatPhong_TestStatusResponse()
        {
            string madoan = "1597429050475";
            var action_result = controller.HuyDatPhong(madoan);
            //
            var actual_result1 = action_result as OkNegotiatedContentResult<List<KhachHangDTO>>;
            var actual_result2 = action_result as BadRequestErrorMessageResult;
            var expected_result1 = "Hủy đặt phòng thành công!";
            var expected_result2 = "Hủy danh sách khách hàng lỗi!";
            //assert1
            try
            {
                Assert.AreEqual(expected_result1, actual_result1.Content);
            }
            catch (Exception)
            {
                Assert.AreEqual(expected_result2, actual_result2.Message);
            }
        }

    }
}
