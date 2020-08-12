using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKSProject;
using QLKSProject.Models.DTO;

namespace QLKSProject_UnitTest
{
    class Data_Test : BaseBusinessUnitTest
    {
        public List<KhachHangDTO> DanhSachKhachHang()
        {
            var lstKH = new List<KhachHangDTO>();
            lstKH.Add(new KhachHangDTO { ID = 1, HoVaTen = "Lưu Vũ Đồng", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 2, HoVaTen = "Phạm Quang Đức", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 3, HoVaTen = "Phạm Quang Tín", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 4, HoVaTen = "Nguyễn Đức Tuấn Anh", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 5, HoVaTen = "Phan Đăng Lưu", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 6, HoVaTen = "Âu cơ", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 8, HoVaTen = "Lạc Long Quân", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO { ID = 9, HoVaTen = "An Dương Vương", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            return lstKH;
        }

        public string TaiKhoan()
        {
            return "{\"UserName\":\"tuangd\",\"UserPassword\":\"123456\",\"UserRoles\":\"ql\",\"PhoneNumber\":\"09483739455\",\"MaDoan\":\"0\",\"IsDelete\":\"false\",\"UserEmailID\":\"tuangd01@gmail.com\",\"UserID\":\"0\",\"FullName\":\"Nguyễn Đức Tuấn Anh\"}";
        }

        public UserMasterDTO TaiKhoanDuocLayMau()
        {
            UserMasterDTO userMaster = new UserMasterDTO();
            userMaster.ID = 132;
            userMaster.UserName = "anhnguyenduc";
            userMaster.UserPassword = "771417";
            userMaster.UserRoles = "nv";
            userMaster.UserEmailID = "anhnguyenduc@gmail.com";
            userMaster.FullName = "Nguyễn Đức Tuấn Anh";
            userMaster.PhoneNumber = "058059900";
            userMaster.UserID = 0;
            userMaster.MaDoan = "";
            userMaster.IsDelete = false;
            return userMaster;
        }
        public int DemSoLuongTaiKhoan()
        {
            var lstTKNhanVien = models.UserMasters.Where(t => t.IsDelete != true && t.UserRoles.Equals("nv")).ToList();
            return lstTKNhanVien.Count();
        }

    }
}
