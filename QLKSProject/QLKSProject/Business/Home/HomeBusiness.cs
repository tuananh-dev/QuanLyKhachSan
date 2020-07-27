using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QLKSProject.Models.DTO;
namespace QLKSProject.Business.Home
{

	public class HomeBusiness : BaseBusiness
	{
		private string error = "ok";
		#region Public methods
		public string LayFileDanhSachKhachHang(string tenDoan, string tenTruongDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string fileDSKhachHang)
		{
			string maDoan = TaoMaDoan().ToString();
			
			try
			{
				TaoDoiTuongDoan(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, maDoan);
				List<KhachHangDTO> lstKhachHang = TaoDoiTuongKhachHang(fileDSKhachHang, maDoan, thoiGianNhan, thoiGianTra, tenTruongDoan);
				if (KiemTraNguoiDaiDien(lstKhachHang))
				{
					if (KiemTraTruongDoan(lstKhachHang))
					{
						LuuDanhSachKhachHang(lstKhachHang);
						models.SaveChanges();
					}
					else
						error = "Lỗi trưởng đoàn không có trong danh sách khách hàng!";
				}
				else
					error = "Lỗi không có người đại diện trẻ em trong danh sách";
			}
			catch (Exception)
			{	
				error = "Lưu file khách hàng không thành công!";
			}
			return error;
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
			doan.TrangThaiDatPhong = 0;
			models.Doans.Add(doan);
		}
		private List<KhachHangDTO> TaoDoiTuongKhachHang(string fileKhachHang, string maDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string tenTruongDoan)
		{
			List<KhachHangDTO> lstKhachHangDTO = new List<KhachHangDTO>();
			string strKhachHang = fileKhachHang.Replace("}", "{");
			strKhachHang = strKhachHang.Replace(":", "");
			strKhachHang = strKhachHang.Replace(",", "");
			string[] lstKhachHang = strKhachHang.Split('{');
			foreach (var item in lstKhachHang)
			{
				string[] lstThuocTinh = item.Split('"');
				if (lstThuocTinh.Length >= 8)
				{
					KhachHangDTO khachHang = new KhachHangDTO();
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
					khachHang.TrangThaiXacNhan = false;
					lstKhachHangDTO.Add(khachHang);
				}
			}
			return lstKhachHangDTO;
		}
		private bool KiemTraNguoiDaiDien(List<KhachHangDTO> khachHangDTOs)
		{
			var lstKhachHang = khachHangDTOs.Where(kh => kh.LoaiKhachHang != false).Select(s => s.NguoiDaiDienCuaTreEm).ToList();
			foreach (var kh in lstKhachHang)
			{
				if (kh.Equals("0"))
					return false;
			}
			List<string> lstNguoiDaiDien = new List<string>();
			foreach (var khachHang in lstKhachHang)
			{
				string[] nguoiDaiDien = khachHang.Split(',');
				foreach (var item in nguoiDaiDien)
				{
					if (item != null)
						lstNguoiDaiDien.Add(item);
				}
			}
			foreach (var nguoiDaiDien in lstNguoiDaiDien)
			{
				var checkNull = khachHangDTOs.Where(kh => kh.HoVaTen.Equals(nguoiDaiDien)).FirstOrDefault();
				if (checkNull != null)
					return false;
			}
			return true;
		}
		private bool KiemTraTruongDoan(List<KhachHangDTO> khachHangDTOs)
		{
			var truongDoan = khachHangDTOs.Where(kh => kh.TruongDoan != false).FirstOrDefault();
			if (truongDoan != null)
				return true;
			else
				return false;
		}
		private void LuuDanhSachKhachHang(List<KhachHangDTO> khachHangDTOs)
		{			
			foreach (var kh in khachHangDTOs)
			{
				Models.Entities.KhachHang khachHang = new Models.Entities.KhachHang();
				khachHang.HoVaTen = kh.HoVaTen;
				khachHang.SoDienThoai = kh.SoDienThoai;
				khachHang.Email = kh.Email;
				khachHang.DiaChi = kh.DiaChi;
				khachHang.Nhom = kh.Nhom;
				khachHang.NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm;
				khachHang.ThoiGianNhan = kh.ThoiGianNhan;
				khachHang.ThoiGianTra = kh.ThoiGianTra;
				khachHang.MaDoan = kh.MaDoan;
				khachHang.GioiTinh = kh.GioiTinh;
				khachHang.LoaiKhachHang = kh.LoaiKhachHang;
				khachHang.TruongDoan = kh.TruongDoan;
				khachHang.IsDelete = kh.IsDelete;
				khachHang.TrangThaiDatPhong = kh.TrangThaiDatPhong;
				khachHang.IDPhong = kh.IDPhong;
				khachHang.GhiChu = kh.GhiChu;
				khachHang.TrangThaiXacNhan = kh.TrangThaiXacNhan;
				models.KhachHangs.Add(khachHang);
			}
		}
		#endregion

	}

}


