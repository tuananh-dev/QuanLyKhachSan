using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;
using System.Net.Http;
using System.IO;

using QLKSProject.Models.DTO;
using System.Web.Http.Controllers;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Net;
using QLKSProject.Controllers.Home;
using QLKSProject.Models;

namespace QLKSProject.Business.Home
{
	public class HomeBusiness : BaseBusiness
	{




		//public bool KiemTraTaiKhoan(TaiKhoan tk)
		//{

		//	var ac = models.TaiKhoans.Where(x => x.TenTaiKhoan == tk.TenTaiKhoan && x.MatKhau == tk.MatKhau && (tk.LoaiTaiKhoan == "QL" || tk.LoaiTaiKhoan == "NV")).FirstOrDefault();
		//	if (tk == null)
		//	{


		//		//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
		//		//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
		//		//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
		//		//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
		//		//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
		//		return true;

		//	}
		//	return false;
		//}
		//public static bool KiemTraTaiKhoan(string TenTaiKhoan, string MatKhau)
		//{
		//	using(HomeBusiness tk = new HomeBusiness())
		//	{
		//		return tk.Users.Any(user => user.TenTaiKhoan.Euqals(TenTaiKhoan,
		//			StringComparison.OrdinalIgnoreCase) && user.MatKhau == MatKhau);
		//	}
		//}
		//public void KiemTraTaiKhoan(HttpActionContext actionContext)
		//{
		//	Models.Entities.TaiKhoan tk = new Models.Entities.TaiKhoan();
		
		//	var ac = models.TaiKhoans.Where(x => x.TenTaiKhoan == tk.TenTaiKhoan && x.MatKhau == tk.MatKhau && (tk.LoaiTaiKhoan == "QL" || tk.LoaiTaiKhoan == "NV")).FirstOrDefault();
		//	if (actionContext.Request.Headers.Authorization == null)
		//	{
		//		actionContext.Response = actionContext.Request.
		//			CreateResponse(HttpStatusCode.Unauthorized);

		//	}
		//	else
		//	{
		//		string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
		//		string decodeAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
		//		string[] tentaikhoanMatkhauArray = decodeAuthenticationToken.Split(':');
		//		string TenTaiKhoan = tentaikhoanMatkhauArray[0];
		//		string MatKhau = tentaikhoanMatkhauArray[1];
		//		if (HomeController.Equals(TenTaiKhoan, MatKhau))
		//		{
		//			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(TenTaiKhoan), null);
		//		}
		//		else
		//		{
		//			actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
		//		}

		//	}

		//}




		public dynamic TestDuLieuTruyenXuong(dynamic dynamic)
		{

			return dynamic;


		}


		#region Public methods
		public bool LayFileDanhSachKhachHang(string tenDoan, string tenTruongDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string fileDSKhachHang)
		{
			string maDoan = TaoMaDoan().ToString();
			TaoDoiTuongDoan(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, maDoan);
			TaoDoiTuongKhachHang(fileDSKhachHang, maDoan, thoiGianNhan, thoiGianTra, tenTruongDoan);
			try
			{
				models.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion

		#region Private methods
		private ulong TaoMaDoan()
		{
			DateTime now = DateTime.Now;
			DateTime time1970 = new DateTime(1970, 1, 1);
			TimeSpan layMa = now - time1970;
			return (ulong)layMa.TotalMilliseconds;
		}
		private void TaoDoiTuongDoan(string tenDoan, string tenTruongDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string maDoan)
		{
			DateTime today = DateTime.Now;
			Models.Entities.Doan doan = new Models.Entities.Doan();
			doan.TenDoan = tenDoan;
			doan.MaDoan = maDoan;
			doan.TenTruongDoan = tenTruongDoan;
			doan.ThoiGianNhan = thoiGianNhan;
			doan.ThoiGianTra = thoiGianTra;
			doan.IsDelete = false;
			doan.NgayGui = today;
			models.Doans.Add(doan);
		}
		private void TaoDoiTuongKhachHang(string fileKhachHang, string maDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string tenTruongDoan)
		{
			string strKhachHang = fileKhachHang.Replace("}", "{");
			strKhachHang = strKhachHang.Replace(":", "");
			strKhachHang = strKhachHang.Replace(",", "");
			string[] lstKhachHang = strKhachHang.Split('{');
			foreach (var item in lstKhachHang)
			{
				string[] lstThuocTinh = item.Split('"');
				if (lstThuocTinh.Length >= 8)
				{
					Models.Entities.KhachHang khachHang = new Models.Entities.KhachHang();
					khachHang.HoVaTen = lstThuocTinh[7];
					khachHang.SoDienThoai = lstThuocTinh[11];
					khachHang.Email = lstThuocTinh[15];
					khachHang.DiaChi = lstThuocTinh[19];
					khachHang.Nhom = int.Parse(lstThuocTinh[23]);
					khachHang.LoaiKhachHang = lstThuocTinh[27].Trim().Equals("nl") ? false : true;
					khachHang.NguoiDaiDienCuaTreEm = lstThuocTinh[31];
					khachHang.GioiTinh = lstThuocTinh[35].Trim().Equals("nu") ? false : true;
					khachHang.IsDelete = false;
					khachHang.MaDoan = maDoan;
					khachHang.ThoiGianNhan = thoiGianNhan;
					khachHang.ThoiGianTra = thoiGianTra;
					khachHang.TruongDoan = khachHang.HoVaTen.Trim().Equals(tenTruongDoan.Trim()) ? true : false;
					models.KhachHangs.Add(khachHang);
				}
			}

		}


	} 
}





