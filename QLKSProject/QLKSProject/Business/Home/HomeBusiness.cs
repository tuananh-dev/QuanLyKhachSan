using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Owin;
using QLKSProject.Models.DTO;
[assembly: OwinStartup(typeof(TokenAuthenticationInWebAPI.App_Start_Startup))]
namespace QLKSProject.Business.Home
{
	public class HomeBusiness : BaseBusiness
	{



		public bool KiemTraTaiKhoan(TaiKhoan tk)
		{

			var ac = models.TaiKhoans.Where(x => x.TenTaiKhoan == tk.TenTaiKhoan && x.MatKhau == tk.MatKhau && (tk.LoaiTaiKhoan == "QL" || tk.LoaiTaiKhoan == "NV")).FirstOrDefault();
			if (tk != null)
			{
				Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
				//Sesion["TenTaiKhoan"] == tk.TenTaiKhoan;
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



