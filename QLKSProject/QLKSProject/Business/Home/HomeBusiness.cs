using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models;
using QLKSProject.Models.Entities;

namespace QLKSProject.Business.Home
{
	public class HomeBusiness : BaseBusiness
	{

		public bool LayFileKhachHangGui(List<FileKhachHang> lstFileKhachHang)
		{

			foreach (var item in lstFileKhachHang)
			{
				KhachHang KhachHang = new KhachHang();
				Doan Doan = new Doan();
				KhachHang.HoVaTen = item.HoVaTen;
				KhachHang.SoDienThoai = item.SoDienThoai;
				KhachHang.Email = item.Email;
				KhachHang.DiaChi = item.DiaChi;
				KhachHang.Nhom = item.Nhom;
				KhachHang.NguoiDaiDienCuaTreEm = item.NguoiDaiDienCuaTreEm;
				KhachHang.ThoiGianNhan = item.ThoiGianNhan;
				KhachHang.ThoiGianTra = item.ThoiGianTra;
				KhachHang.MaDoan = item.MaDoan;
				KhachHang.GioiTinh = item.GioiTinh;
				KhachHang.LoaiKhachHang = item.LoaiKhachHang;
				KhachHang.TruongDoan = item.TruongDoan;
				KhachHang.IsDelete = true;
				KhachHang.Doan_MaDoan = item.Doan_MaDoan;
				Doan.MaDoan = item.MaDoan;
				Doan.TenDoan = item.TenDoan;
				Doan.NgayGui = item.NgayGui;
				Doan.TenTruongDoan = item.TenTruongDoan;
				Doan.ThoiGianNhan = item.ThoiGianNhan;
				Doan.ThoiGianTra = item.ThoiGianTra;
				Doan.IsDelete = true;

				try
				{
					models.KhachHangs.Add(KhachHang);
					models.Doans.Add(Doan);
					models.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					Console.WriteLine("Loi lay du lieu DanhSachFileGui");
					return false;
				}
			}
			return false;

		}
	}
}