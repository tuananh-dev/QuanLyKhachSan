using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models;

namespace QLKSProject.Business
{
    public class KhoiTaoCSDL : BaseBusiness
    {
        private Random rd = new Random();
        #region Public Methods
        public bool TaoCSDL()
        {
            bool b = true;
            try
            {
                TaoPhong(2, 2);
                TaoDichVu();
                TaoTaiKhoan();
                TaoTienIch();
            }
            catch (Exception)
            {
                b = false;
                throw;
            }
            models.SaveChanges();
            return b;
        }
        #endregion


        #region Private Methods
        private void TaoPhong(int soPhong, int soTang)
        {
            for(int i = 1; i <= soTang; i++)
            {
                for(int j = 1; j<= soPhong; j++)
                {
                    DateTime dateTime = DateTime.Now;
                    Phong phong = new Phong();
                    phong.SoPhong = (i * 100 + j) + "";
                    phong.MaPhong = dateTime.Millisecond.ToString();
                    phong.LoaiPhong = rd.Next(1, 4).ToString();
                    phong.Gia = rd.Next(1, 4)*1000000;
                    if (rd.Next(0, 1) == 1)
                        phong.TrangThai = false;
                    else
                        phong.TrangThai = true;
                    if (rd.Next(1, 10) == 2)
                        phong.IsDelete = true;
                    else
                        phong.IsDelete = false;
                    try
                    {
                        models.Phongs.Add(phong);
                       
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Loi luu doi tuong xuong csdl !!!");
                    }

                }
            }
        }
        private void TaoDichVu()
        {
            string[] lstTenDichVu = { "An Uong", "Thue Xe", "Giat Ui","Massage" };
            for(int i = 0; i < lstTenDichVu.Length; i++)
            {
                DichVu dichVu = new DichVu();
                dichVu.TenDichVu = lstTenDichVu[i];
                dichVu.Gia = rd.Next(3, 15) * 100000;
                if (rd.Next(0, 10) == 0)
                    dichVu.IsDelete = true;
                else
                    dichVu.IsDelete = false;
                try
                {
                    models.DichVus.Add(dichVu);

                }
                catch (Exception)
                {

                    Console.WriteLine("Loi luu Dich Vu !!!");
                }
            }
        }
        private void TaoTaiKhoan()
        {
            string[] lstTenTaiKhoan = { "anhnguyenduc", "ducpham", "nhatnam", "hanam", "huyphuc", "loinguyen" };
            string[] lstHovaten = { "Nguyen Duc Tuan Anh", "Pham Quang Duc", "Nguyen Nhat Nam","Nguyen Dinh Ha Nam", "Nguyen Huy Phuc", "Nguyen Van Loi" };
            for(int i = 0; i < lstTenTaiKhoan.Length; i++)
            {
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TenTaiKhoan = lstTenTaiKhoan[i];
                taiKhoan.HoVaTen = lstHovaten[i];
                taiKhoan.MatKhau = rd.Next(111, 333).ToString();
                taiKhoan.SoDienThoai = "0" + rd.Next(23456789, 88765432).ToString();
                taiKhoan.Mail = lstTenTaiKhoan[i] + "@gmail.com";
                switch (rd.Next(1, 4))
                {
                    case 1: taiKhoan.LoaiTaiKhoan = "NV";break;
                    case 2: taiKhoan.LoaiTaiKhoan = "QL";break;
                    case 3: taiKhoan.LoaiTaiKhoan = "KH";break;
                    case 4: taiKhoan.LoaiTaiKhoan = "AM";break;
                }
                if (rd.Next(0, 10) == 0)
                    taiKhoan.IsDelete = true;
                else
                    taiKhoan.IsDelete = false;
                try
                {
                    models.TaiKhoans.Add(taiKhoan);
                }
                catch (Exception)
                {
                    Console.WriteLine("Loi luu tai khoan");
                }
            }
        }
        private void TaoTienIch()
        {
            string[] lstTenTienIch = { "Wifi Free", "Ga trai giuong", "Tu quan ao", "Tu lanh","Ti vi","Bon tam" };
            for (int i = 0; i < lstTenTienIch.Length; i++)
            {
                TienIch tienIch = new TienIch();
                tienIch.TenTienIch = lstTenTienIch[i];
                tienIch.HinhAnh = lstTenTienIch[i] + "picture";   
                if (rd.Next(0, 10) == 0)
                    tienIch.IsDelete = true;
                else
                    tienIch.IsDelete = false;
                try
                {
                    models.TienIches.Add(tienIch);

                }
                catch (Exception)
                {

                    Console.WriteLine("Loi luu Tien Ich !!!");
                }
            }

        }
        #endregion

    }
}