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
                TaoPhong(9, 9);
                /*                TaoDichVu();*/
/*                TaoTaiKhoan();*/
/*                TaoTienIch();*/
                /*                TaoDoanKhachHang(12);*/
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
        private void TaoPhong(int soTang, int soPhong)
        {
            int sum = soTang * soPhong;
            int x = 1;
            for (int i = 1; i <= soTang; i++)
            {
                for (int j = 1; j <= soPhong; j++)
                {
                    Phong phong = new Phong();
                    phong.SoPhong = (i * 100 + j) + "";
                    phong.MaPhong = rd.Next(1, 4).ToString() + (i < 10 ? "0" + i : "" + i) + (j < 10 ? "0" + j : "" + j);
                    phong.LoaiPhong = x<(sum/3)?1:rd.Next(1, 5);
                    phong.Gia = rd.Next(1, 5) * 1000000;
                    phong.TrangThai = -1;
                    if (rd.Next(1, 10) == 2)
                        phong.IsDelete = true;
                    else
                        phong.IsDelete = false;
                    x++;
                    models.Phongs.Add(phong);
                }
            }
        }
        private void TaoDoanKhachHang(int soluong)
        {
            string[] tenDuong = { "Nguyễn Văn Trỗi", "Hàm Nghi", "Cách Mạng Tháng 8", "Lê Hữu Thọ", "Lê Trọng Tấn", "Phạm Văn Đồng", "An Dương Vương", "Võ Thị Sáu", "Phan Đình Phùng", "Lê Lai", "Lê Lợi" };
            for (int i = 0; i <= soluong; i++)
            {
                Doan doan = TaoDoan();

                for (int j = 0; j < rd.Next(5, 30); j++)
                {
                    KhachHang khachHang = new KhachHang();
                    if (j == 0)
                        khachHang.HoVaTen = doan.TenTruongDoan;
                    else
                        khachHang.HoVaTen = TaoTenKhachHang();

                    khachHang.SoDienThoai = "098" + rd.Next(222222, 999999);
                    khachHang.Email =RemoveUnicode(khachHang.HoVaTen.ToLower().Replace(" ", "") + "@gmail.com");
                    khachHang.DiaChi = rd.Next(1, 1234) + " " + tenDuong[rd.Next(0, tenDuong.Length - 1)];
                    khachHang.Nhom = rd.Next(1, 10);
                    khachHang.ThoiGianNhan = doan.ThoiGianNhan;
                    khachHang.ThoiGianTra = doan.ThoiGianTra;
                    khachHang.MaDoan = doan.MaDoan;
                    khachHang.GioiTinh = (rd.Next(0, 2) == 1) ? true : false;
                    khachHang.LoaiKhachHang = (rd.Next(0, 20) == 3) ? true : false;
                    khachHang.TruongDoan = (j == 0) ? true : false;
                    khachHang.TrangThaiDatPhong = -1;
                    khachHang.IsDelete = false;
                    khachHang.IDPhong = -1;
                    models.KhachHangs.Add(khachHang);
                }
                models.Doans.Add(doan);
            }
        }
        private void TaoDichVu()
        {
            string[] lstTenDichVu = { "Ăn Uống", "Thuê Xe", "Giặt ỦI", "Massage" };
            for (int i = 0; i < lstTenDichVu.Length; i++)
            {
                DichVu dichVu = new DichVu();
                dichVu.TenDichVu = lstTenDichVu[i];
                dichVu.Gia = rd.Next(3, 15) * 100000;
                dichVu.MoTa = lstTenDichVu[i];
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
            string[] lstHovaten = { "Nguyễn Đức Tuấn Anh", "Phạm Quang Đức", "Nguyễn Nhật Nam", "Nguyễn Đình Hà Nam", "Nguyễn Huy Phúc", "Nguyễn Văn Lợi" };
            for (int i = 0; i < lstTenTaiKhoan.Length; i++)
            {
                UserMaster userMaster = new UserMaster();
                userMaster.UserName = lstTenTaiKhoan[i];
                userMaster.FullName = lstHovaten[i];
                userMaster.UserPassword = rd.Next(111111, 999999).ToString();
                userMaster.PhoneNumber = "0" + rd.Next(23456789, 88765432).ToString();
                userMaster.UserEmailID = lstTenTaiKhoan[i] + "@gmail.com";
                userMaster.MaDoan = "0";
                switch (rd.Next(1, 5))
                {
                    case 1: userMaster.UserRoles = "nv"; break;
                    case 2: userMaster.UserRoles = "ql"; break;
                    case 3: userMaster.UserRoles = "kh"; break;
                    case 4: userMaster.UserRoles = "ad"; break;
                }
                if (rd.Next(0, 10) == 0)
                    userMaster.IsDelete = true;
                else
                    userMaster.IsDelete = false;
                try
                {
                    models.UserMasters.Add(userMaster);
                }
                catch (Exception)
                {
                    Console.WriteLine("Loi luu tai khoan");
                }
            }
        }
        private void TaoTienIch()
        {
            string[] lstTenTienIch = { "Wifi Free", "Ga Trải Giường", "Tủ Quần Áo", "Tủ Lạnh", "Ti Vi", "Bồn Tắm" };
            for (int i = 0; i < lstTenTienIch.Length; i++)
            {
                TienIch tienIch = new TienIch();
                tienIch.TenTienIch = lstTenTienIch[i];
                tienIch.MoTa = lstTenTienIch[i] + " picture";
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
            string[] ten = { "12A4", "76", "Thiên Minh", "Phúc Long", "99", "51", "Hải Long", "Phương Nam", "8A9", "Thanh Niên", "Văn Lang", "CNNT", "Cô Ba", "Covid" };
            string[] tenDem = { "Vũng Tàu", "Sài Gòn", "Vĩnh Phúc", "Bắc Giang", "Hà Nội", "Vinh", "Lạng Sơn", "Lào Cai", "Dân Trí", "Bến Tre" };
            return "Doan" + ten[rd.Next(0, ten.Length - 1)] + tenDem[rd.Next(0, tenDem.Length - 1)];
        }
        private string TaoTenKhachHang()
        {
            string[] ten = { "Nam", "Bắc", "Đông", "Tây", "Linh", "Sáu", "Anh", "An", "Phượng", "Phương", "Chuyên", "Thủy", "Sơn", "Lam", "Lan", "Hương", "Thảo", "Trang", "Dân", "Vinh", "Trung", "Hoàng", "Lợi", "Đức", "Phúc", "My", "Thọ" };
            string[] tenDem = { "Đức", "Văn", "Phương", "Như", "Ngọc", "Bảo", "Thi", "Tuấn", "Tân", "Thiên", "Ngân", "Gia", "Bình", "Thương" };
            string[] ho = { "Nguyễn", "Trần", "Lê", "Hồ", "Đinh", "Lưu", "Huỳnh", "Trịnh", "Lý", "Phan", "Vũ", "Võ", "Đoàn" };
            if (rd.Next(0, 2) == 1)
                return ho[rd.Next(0, ho.Length - 1)] + " " + tenDem[rd.Next(0, tenDem.Length - 1)] + " " + ten[rd.Next(0, ten.Length - 1)];
            else
                return ho[rd.Next(0, ho.Length - 1)] + " " + ten[rd.Next(0, ten.Length - 1)] + " " + tenDem[rd.Next(0, tenDem.Length - 1)] + " " + ten[rd.Next(0, ten.Length - 1)];
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