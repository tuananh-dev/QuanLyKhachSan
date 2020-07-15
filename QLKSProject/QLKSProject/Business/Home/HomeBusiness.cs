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
			TaoDoiTuongDoan(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, maDoan);


				using (StreamWriter sw = new StreamWriter("C:\\Users\\TuA\\Documents\\1. VLU\\textfile.txt"))
				{
					sw.WriteLine(fileDSKhachHang);
				}

			models.SaveChanges();
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
			doan.TenDoan = tenDoan;
			doan.MaDoan = maDoan;
			doan.TenTruongDoan = tenTruongDoan;
			doan.ThoiGianNhan = thoiGianNhan;
			doan.ThoiGianTra = thoiGianTra;
			doan.IsDelete = false;
			doan.NgayGui = today;
			models.Doans.Add(doan);
		}
		private void TaoDoiTuongKhachHang(string fileKhachHang, string maDoan, DateTime thoiGianNhan, DateTime thoiGianTra)
		{

		}
		#endregion
	}
}

