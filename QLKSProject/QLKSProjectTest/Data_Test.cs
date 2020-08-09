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
    class Data_Test
    {
        public List<KhachHangDTO> DanhSachKhachHang()
        {
            var lstKH = new List<KhachHangDTO>();
            lstKH.Add(new KhachHangDTO{ ID = 1,HoVaTen = "Lưu Vũ Đồng", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222"});
            lstKH.Add(new KhachHangDTO{ ID = 2,HoVaTen = "Phạm Quang Đức", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO{ ID = 3,HoVaTen = "Phạm Quang Tín", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO{ ID = 4,HoVaTen = "Nguyễn Đức Tuấn Anh", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO{ ID = 5,HoVaTen = "Phan Đăng Lưu", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO{ ID = 6,HoVaTen = "Âu cơ", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO{ ID = 8,HoVaTen = "Lạc Long Quân", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            lstKH.Add(new KhachHangDTO{ ID = 9,HoVaTen = "An Dương Vương", SoDienThoai = "1307758298", Email = "khach1@xxx.com", DiaChi = "Lane 1588 Zhuguang Road, Trung Quốc", Nhom = 1, LoaiKhachHang = false, NguoiDaiDienCuaTreEm = "0", GioiTinh = false, MaDoan = "222" });
            return lstKH;
        }
    }
}
