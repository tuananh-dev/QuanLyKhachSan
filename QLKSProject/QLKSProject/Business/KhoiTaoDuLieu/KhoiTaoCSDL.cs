using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models.Entities;
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
                TaoPhong(9, 22);
                TaoDichVu();
                TaoTaiKhoan();
                TaoTienIch();
                TaoDoanKhachHang(12);
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
        private void TaoPhong(int soTang, int soPhong )
        {
            for (int i = 1; i <= soTang; i++)
            {
                for (int j = 1; j <= soPhong; j++)
                {
                    Phong phong = new Phong();
                    phong.SoPhong = (i * 100 + j) + "";
                    phong.MaPhong = rd.Next(1, 4).ToString() + (i < 10 ? "0" + i : "" + i) + (j < 10 ? "0" + j : "" + j);
                    phong.LoaiPhong = rd.Next(1, 4).ToString();
                    phong.Gia = rd.Next(1, 5) * 1000000;
                    if (rd.Next(0, 2) == 1)
                        phong.TrangThai = false;
                    else
                        phong.TrangThai = true;
                    if (rd.Next(1, 10) == 2)
                        phong.IsDelete = true;
                    else
                        phong.IsDelete = false;

                    models.Phongs.Add(phong);
                }
            }
        }
        private void TaoDoanKhachHang(int soluong)
        {
            string[] tenDuong = { "Nguyen Van Troi", "Ham Nghi", "Cach Mang Thang 8", "Le Huu Tho", "Le Trong Tan", "Pham Van Dong", "Mai Duong Vuong", "Vo Thi Sau", "Phan Dinh Phung", "Le Lai", "Le Loi" };
            for (int i = 0; i <= soluong; i++)
            {
                Doan doan = new Doan();
                doan = TaoDoan();
                for (int j = 0; j < rd.Next(5, 30); j++)
                {
                    KhachHang khachHang = new KhachHang();
                    if (j == 0)
                        khachHang.HoVaTen = doan.TenTruongDoan;
                    else
                        khachHang.HoVaTen = TaoTenKhachHang();

                    khachHang.SoDienThoai = "098" + rd.Next(222222, 999999);
                    khachHang.Email = khachHang.HoVaTen.ToLower().Replace(" ", "") + "@gmail.com";
                    khachHang.DiaChi = rd.Next(1, 1234) + " " + tenDuong[rd.Next(0, tenDuong.Length - 1)];
                    khachHang.Nhom = "n" + rd.Next(1, 10);
                    khachHang.ThoiGianNhan = doan.ThoiGianNhan;
                    khachHang.ThoiGianTra = doan.ThoiGianTra;
                    khachHang.MaDoan = doan.MaDoan;
                    khachHang.GioiTinh = (rd.Next(0, 2) == 1) ? true : false;
                    khachHang.LoaiKhachHang = (rd.Next(0, 20) == 3) ? true : false;
                    khachHang.TruongDoan = (j == 0) ? true : false;
                    khachHang.IsDelete = false;

                    models.KhachHangs.Add(khachHang);
                    models.Doans.Add(doan);
                }
            }
        }
        private void TaoDichVu()
        {
            string[] lstTenDichVu = { "An Uong", "Thue Xe", "Giat Ui", "Massage" };
            for (int i = 0; i < lstTenDichVu.Length; i++)
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
            string[] lstHovaten = { "Nguyen Duc Tuan Anh", "Pham Quang Duc", "Nguyen Nhat Nam", "Nguyen Dinh Ha Nam", "Nguyen Huy Phuc", "Nguyen Van Loi" };
            for (int i = 0; i < lstTenTaiKhoan.Length; i++)
            {
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TenTaiKhoan = lstTenTaiKhoan[i];
                taiKhoan.HoVaTen = lstHovaten[i];
                taiKhoan.MatKhau = rd.Next(111, 333).ToString();
                taiKhoan.SoDienThoai = "0" + rd.Next(23456789, 88765432).ToString();
                taiKhoan.Mail = lstTenTaiKhoan[i] + "@gmail.com";
                switch (rd.Next(1, 5))
                {
                    case 1: taiKhoan.LoaiTaiKhoan = "NV"; break;
                    case 2: taiKhoan.LoaiTaiKhoan = "QL"; break;
                    case 3: taiKhoan.LoaiTaiKhoan = "KH"; break;
                    case 4: taiKhoan.LoaiTaiKhoan = "AM"; break;
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
            string[] lstTenTienIch = { "Wifi Free", "Ga trai giuong", "Tu quan ao", "Tu lanh", "Ti vi", "Bon tam" };
            for (int i = 0; i < lstTenTienIch.Length; i++)
            {
                TienIch tienIch = new TienIch();
                tienIch.TenTienIch = lstTenTienIch[i];
                tienIch.HinhAnh = lstTenTienIch[i] + " picture";
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
        private Doan TaoDoan()
        {
            Doan newDoan = new Doan();
            newDoan.MaDoan = TaoMaDoan().ToString();
            newDoan.TenDoan = TaoTenDoan();
            newDoan.TenTruongDoan = TaoTenKhachHang();
            newDoan.ThoiGianNhan = TaoThoiGian();
            newDoan.NgayGui = newDoan.ThoiGianNhan;
            newDoan.ThoiGianTra = TaoThoiGian();
            if (newDoan.ThoiGianTra.CompareTo(newDoan.ThoiGianNhan) == -1)
            {
                var time = newDoan.ThoiGianTra;
                newDoan.ThoiGianTra = newDoan.ThoiGianNhan;
                newDoan.ThoiGianNhan = time;
            }
            newDoan.IsDelete = false;
            return newDoan;
        }
        private ulong TaoMaDoan()
        {
            DateTime now = DateTime.Now;
            DateTime time1970 = new DateTime(1970, 1, 1);
            TimeSpan layMa = now - time1970;
            return (ulong)layMa.TotalMilliseconds;
        }
        private string TaoTenDoan()
        {
            string[] ten = { "12A4", "76", "ThienMinh", "Phuc Long", "99", "51", "Hai Long", "Phuong Nam", "8A9", "Thanh Nien", "Van Lang", "CNNT", "Co Ba", "Covid" };
            string[] tenDem = { "Vung Tau", "Sai Gon", "Vinh Phuc", "Bac Giang", "Ha Noi", "Vinh", "Lang Son", "Lao Cai", "Tien Giang", "Ben Tre" };
            return "Doan" + ten[rd.Next(0, ten.Length - 1)] + tenDem[rd.Next(0, tenDem.Length - 1)];
        }
        private string TaoTenKhachHang()
        {
            string[] ten = { "Nam", "Bac", "Dong", "Tay", "Nam", "Sau", "Anh", "An", "Phuong", "Chuyen", "Thuy", "Son", "Lam", "Lan", "Huong", "Thao", "Trang", "Dan", "Vinh", "Trung", "Hoang", "Loi", "Duc", "Phuc", "My" };
            string[] tenDem = { "Duc", "Van", "Phuong", "Nhu", "Ngoc", "Bao", "Thi", "Tuan", "Tan", "Thien", "Ngan", "Gia", "Binh", "Tuong" };
            string[] ho = { "Nguyen", "Tran", "Le", "Ho", "Dinh", "Luu", "Huynh", "Trinh", "Ly", "Phan", "Vu" };
            if (rd.Next(0, 2) == 1)
                return ho[rd.Next(0, ho.Length - 1)] + " " + tenDem[rd.Next(0, tenDem.Length - 1)] + " " + ten[rd.Next(0, ten.Length - 1)];
            else
                return ho[rd.Next(0, ho.Length - 1)]+" " + ten[rd.Next(0, ten.Length - 1)] + " " + tenDem[rd.Next(0, tenDem.Length - 1)] + " " + ten[rd.Next(0, ten.Length - 1)];
        }
        private DateTime TaoThoiGian()
        {
            DateTime from = new DateTime(2010, 1, 1);
            DateTime to = new DateTime(2019, 12, 12);
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(rd.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }
        #endregion

    }
}