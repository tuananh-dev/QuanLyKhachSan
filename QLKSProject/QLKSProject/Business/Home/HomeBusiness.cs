using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.UI;
using QLKSProject.Models.DTO;
namespace QLKSProject.Business.Home
{
	public class HomeBusiness : BaseBusiness
	{




			public bool LayFileDanhSachKhachHang(List<FileKhachHang> lstfileKhachHang)
			{
				foreach (var item in lstfileKhachHang)
				{
					Models.Entities.KhachHang KhachHang = new Models.Entities.KhachHang();
					Models.Entities.Doan Doan = new Models.Entities.Doan();
					KhachHang.HoVaTen = item.HoVaTen;
					KhachHang.SoDienThoai = item.SoDienThoai;
					KhachHang.Email = item.Email;
					KhachHang.DiaChi = item.DiaChi;
					KhachHang.NguoiDaiDienCuaTreEm = item.NguoiDaiDienCuaTreEm;
					KhachHang.ThoiGianNhan = item.ThoiGianNhan;
					KhachHang.ThoiGianTra = item.ThoiGianTra;
					KhachHang.MaDoan = item.MaDoan;
					KhachHang.GioiTinh = item.GioiTinh;
					KhachHang.LoaiKhachHang = item.LoaiKhachHang;
					KhachHang.TruongDoan = item.TruongDoan;
					KhachHang.IsDelete = false;
					Doan.MaDoan = item.MaDoan;
					Doan.TenDoan = item.TenDoan;
					Doan.NgayGui = item.NgayGui;
					Doan.TenTruongDoan = item.TenTruongDoan;
					Doan.ThoiGianNhan = item.ThoiGianNhan;
					Doan.ThoiGianTra = item.ThoiGianTra;
					Doan.IsDelete = false;
					models.KhachHangs.Add(KhachHang);
					models.Doans.Add(Doan);
				}
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
			public bool KiemTraTaiKHoan(TaiKhoan tk)
			{

			var tk = models.TaiKhoans.Where(x => x.TenTaiKhoan == TenTaiKhoan && x.MatKhau == MatKhau) && (tk.LoaiTK == "QL" || tk.LoaiTK =="NV")).FirstOrDefault();
			if (TaiKhoan !=null)
			{
				Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				return true;

			}
			return false;
		}



		public dynamic TestDuLieuTruyenXuong(dynamic dynamic)
			{

				return dynamic;


			}
		}



	} 
}