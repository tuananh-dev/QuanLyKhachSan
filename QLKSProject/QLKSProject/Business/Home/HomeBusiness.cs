using System;
using System.Collections.Generic;
using QLKSProject.Models.DTO;
namespace QLKSProject.Business.Home
{
	public class HomeBusiness : BaseBusiness
	{
		public string TestDuLieuTruyenXuong(dynamic dynamic)
		{
            //using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter(@"D:/WriteLines2.txt", false))
            //{
               
            //    file.WriteLine(s);
            //    file.Close();
            //}
            string s = dynamic.ToString();
            return s;
		}
	}
}
