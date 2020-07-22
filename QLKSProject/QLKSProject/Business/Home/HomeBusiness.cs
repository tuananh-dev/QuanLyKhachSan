using System;
using System.Collections.Generic;
using System.IO;
using QLKSProject.Models.DTO;
namespace QLKSProject.Business.Home
{
<<<<<<< HEAD

=======
>>>>>>> 0f476819cdcc92c0f9f689116f1f48660f7255d9
	public class HomeBusiness : BaseBusiness
	{
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
					khachHang.TrangThaiDatPhong = false;
					khachHang.IDPhong = -1;
					models.KhachHangs.Add(khachHang);
				}
			}

		}
		#endregion

		/*using (StreamWriter sw = new StreamWriter("C:\\Users\\TuA\\Documents\\1. VLU\\textfile.txt"))
		  {
		    for(int i = 0; i<lstThuocTinh.Length;i++)
				sw.WriteLine(lstThuocTinh[i]+i);
          }*/
	}

}


