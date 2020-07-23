using System;
using System.Collections.Generic;
using System.IO;
using QLKSProject.Models.DTO;
namespace QLKSProject.Business.Home
{

	public class HomeBusiness : BaseBusiness
	{
		#region Public methods
		public bool LayFileDanhSachKhachHang(string tenDoan, string tenTruongDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string fileDSKhachHang)
		{
			string maDoan = TaoMaDoan().ToString();
			
			try
			{
				TaoDoiTuongDoan(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, maDoan);
				TaoDoiTuongKhachHang(fileDSKhachHang, maDoan, thoiGianNhan, thoiGianTra, tenTruongDoan);
				models.SaveChanges();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
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
			doan.MaDoan = maDoan;
			doan.TenDoan = tenDoan;
			doan.NgayGui = today;
			doan.TenTruongDoan = tenTruongDoan;
			doan.ThoiGianNhan = thoiGianNhan;
			doan.ThoiGianTra = thoiGianTra;
			doan.IsDelete = false;
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
					khachHang.NguoiDaiDienCuaTreEm = lstThuocTinh[31];
					khachHang.ThoiGianNhan = thoiGianNhan;
					khachHang.ThoiGianTra = thoiGianTra;
					khachHang.MaDoan = maDoan;
					khachHang.GioiTinh = lstThuocTinh[35].Trim().Equals("nu") ? false : true;
					khachHang.LoaiKhachHang = lstThuocTinh[27].Trim().Equals("nl") ? false : true;
					khachHang.TruongDoan = khachHang.HoVaTen.Trim().Equals(tenTruongDoan.Trim()) ? true : false;
					khachHang.IsDelete = false;
					khachHang.TrangThaiDatPhong = false;
					khachHang.IDPhong = -1;
					models.KhachHangs.Add(khachHang);

				}
			}


		}
		#endregion


	}

}


