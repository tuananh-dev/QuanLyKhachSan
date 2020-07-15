using System;
using System.Collections.Generic;
using System.IO;
using QLKSProject.Models.DTO;
namespace QLKSProject.Business.Home
{
	public class HomeBusiness : BaseBusiness
	{
		public bool LayFileDanhSachKhachHang(dynamic dynamic)
		{
			using (StreamWriter sw = new StreamWriter("C:\\Users\\TuA\\Documents\\1. VLU\\textfile.txt"))
			{
				sw.WriteLine(dynamic.Files.ToString());
			}
			return true;
		}
	}
}

