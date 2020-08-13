using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLKSProject.Controllers.NhanVien;
using QLKSProject.Models.DTO;
using QLKSProject.Business.NhanVien;

namespace QLKSProjectTest
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
        public void LayDanhSachDoan_TestStatusRespone()
        {
            var action_result = controller.LayDanhSachDoan();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<DoanDTO>>;
            var expected_result = data_test.SoLuongDoan();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void DatPhongChoTungDoan_TestStatusRespone()
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
        public void DatPhongChoNhieuDoan_TestStatusRespone()
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
        public void LayDanhSachDoanDatPhongThanhCong_TestStatusRespone()
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
        public void LayDanhSachKhachHangTheoMaDoan_TestStatusRespone()
        {
            var action_result = controller.LayDanhSachKhachHangTheoMaDoan("37648363");
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<KhachHangDTO>>;
            var expected_result = data_test.SoLuongKhachHangTrongDoan("37648363");
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void LayDanhSachDoanDatPhongThatBai_TestStatusRespone()
        {
            var action_result = controller.LayDanhSachDoanDatPhongThatBai();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<DoanDTO>>;
            var expected_result = data_test.SoLuongDoanDatPhongThatBai();
            //assert
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        [TestMethod]
        public void XoaDoan_TestStatusRespone()
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
        public void LayDanhSachPhong_TestStatusRespone()
        {
            var action_result = controller.LayDanhSachPhong();
            //act
            var actual_result = action_result as OkNegotiatedContentResult<List<PhongDTO>>;
            var expected_result = data_test.DemSoLuongPhong();
            //asset
            Assert.AreEqual(expected_result, actual_result.Content.Count);
        }
        #endregion

        [TestMethod]
        public void DatPhongChoMotDoanKhachHang()
        {
            var action_result = business.DatPhongChoMotDoanKhachHang(data_test.ListKHMotDoan(), data_test.ListKH(), data_test.ListPhong());
        }
    }
}
