using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKSProject;
using QLKSProject.Models.DTO;
using QLKSProject.Business.QuanLy;
using QLKSProject.Business.NhanVien;
using QLKSProject.Business.Home;
using QLKSProject.Business.KhachHangBusiness;

namespace QLKSProjectTest
{
    class Data_Test : BaseBusinessUnitTest
    {
        private List<KhachHangDTO> khachHangDTOs;
        private List<KhachHangDTO> khachHang_MotDoanDTOs;
        private List<PhongDTO> phongDTOs;
        public int idPhong;
        private NhanVienBusiness nhanvien;
        private HomeBusiness home;
        private KhachHangBusiness khachhang;
        public Data_Test()
        {
            khachHang_MotDoanDTOs = models.KhachHangs.Where(kh => kh.MaDoan.Equals("1597352230776")).Select(kh => new KhachHangDTO
            {
                ID = kh.ID,
                HoVaTen = kh.HoVaTen,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                DiaChi = kh.DiaChi,
                Nhom = kh.Nhom,
                NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm,
                ThoiGianNhan = kh.ThoiGianNhan,
                ThoiGianTra = kh.ThoiGianTra,
                MaDoan = kh.MaDoan,
                GioiTinh = kh.GioiTinh,
                LoaiKhachHang = kh.LoaiKhachHang,
                TruongDoan = kh.TruongDoan,
                IsDelete = kh.IsDelete,
                TrangThaiDatPhong = kh.TrangThaiDatPhong,
                IDPhong = kh.IDPhong,
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();
            khachHangDTOs = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong >= 0 && kh.IsDelete != true).Select(kh => new KhachHangDTO
            {
                ID = kh.ID,
                HoVaTen = kh.HoVaTen,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                DiaChi = kh.DiaChi,
                Nhom = kh.Nhom,
                NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm,
                ThoiGianNhan = kh.ThoiGianNhan,
                ThoiGianTra = kh.ThoiGianTra,
                MaDoan = kh.MaDoan,
                GioiTinh = kh.GioiTinh,
                LoaiKhachHang = kh.LoaiKhachHang,
                TruongDoan = kh.TruongDoan,
                IsDelete = kh.IsDelete,
                TrangThaiDatPhong = kh.TrangThaiDatPhong,
                IDPhong = kh.IDPhong,
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();
            phongDTOs = models.Phongs.Where(p => p.IsDelete != true).Select(p => new PhongDTO
            {
                ID = p.ID,
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.LoaiPhong,
                Gia = p.Gia,
                TrangThai = p.TrangThai,
                IsDelete = p.IsDelete
            }).ToList();
            idPhong = 236;
            nhanvien = new NhanVienBusiness();
            home = new HomeBusiness();
            khachhang = new KhachHangBusiness(); 
        }
        public List<KhachHangDTO> ListKHMotDoan()
        {
            return khachHang_MotDoanDTOs;
        }
        public List<KhachHangDTO> ListKH()
        {
            return khachHangDTOs;
        }
        public List<PhongDTO> ListPhong()
        {
            return phongDTOs;
        }
        //Quan Ly
        #region DS Khach Hang
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
        #endregion
        #region TaiKhoan
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
        #endregion
        #region Phong
        public int DemSoLuongPhong()
        {
            return models.Phongs.Where(p => p.IsDelete != true).Count();
        }
        public PhongDTO LayThongTinPhong()
        {
            return models.Phongs.Select(e => new PhongDTO
            {
                ID = e.ID,
                MaPhong = e.MaPhong,
                SoPhong = e.SoPhong,
                LoaiPhong = e.LoaiPhong,
                Gia = e.Gia,
                TrangThai = e.TrangThai,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
        }
        public string TaoMoiPhong()
        {
            return "{\"MaPhong\":\"41235\",\"SoPhong\":\"1235\",\"LoaiPhong\":\"4\",\"Gia\":\"4000000\",\"TrangThai\":\"-1\",\"IsDelete\":\"false\"}";
        }
        #endregion
        #region Dich Vu
        public int SoLuongDichVu()
        {
            return models.DichVus.Where(d => d.IsDelete != true).Count();
        }
        public DichVuDTO LayThongTinDichVu()
        {
            return models.DichVus.Where(d => d.IsDelete != true).Select(d => new DichVuDTO
            {
                ID = d.ID,
                TenDichVu = d.TenDichVu,
                Gia = d.Gia,
                MoTa = d.MoTa,
                IsDelete = d.IsDelete
            }).FirstOrDefault();
        }
        public string TaoMoiDichVu()
        {
            return "{\"TenDichVu\":\"Karaoke\",\"MoTa\":\"Dan am thanh vo cung chat luong\",\"Gia\":\"3000000\",\"IsDelete\":\"false\"}";
        }
        public void PhucHoiDichVu(int id)
        {
            try
            {
                var dich_vu = models.DichVus.Where(d => d.ID == id).FirstOrDefault();
                dich_vu.IsDelete = false;
                models.SaveChanges();
            }
            catch (Exception)
            {
            }

        }
        #endregion
        #region Tien Ich
        public int SoLuongTienIch()
        {
            return models.TienIches.Where(t => t.IsDelete != true).Count();
        }
        public TienIchDTO LayThongTinTienIch()
        {
            return models.TienIches.Where(t => t.IsDelete != true).Select(t => new TienIchDTO
            {
                ID = t.ID,
                TenTienIch = t.TenTienIch,
                MoTa = t.MoTa,
                IsDelete = t.IsDelete
            }).FirstOrDefault();
        }
        public string TaoMoiTienIch()
        {
            return "{\"TenTienIch\":\"Ban Công\",\"MoTa\":\"Ban công có view nhìn ra biển thoáng đãng\",\"IsDelete\":\"false\"}";
        }
        public List<ThongKeTheoThangDTO> BaoCaoThongKeTheoThang(int thang, int nam)
        {
            var business = new QuanLyBusiness();
            return business.BaoCaoThongKeTheoThang(thang, nam);
        }
        public SoSanhThongKeDTO SoSanhThongKeTheoThang(int thang, int nam)
        {
            var business = new QuanLyBusiness();
            return business.SoSanhThongKeTheoThang(thang, nam);
        }
        public SoSanhThongKeDTO SoSanhThongKeTheoQuy(int quy, int nam)
        {
            var business = new QuanLyBusiness();
            return business.SoSanhThongKeTheoQuy(quy, nam);
        }
        public void PhucHoiTienIchBiXoa(int id)
        {
            try
            {
                var tien_ich = models.TienIches.Where(t => t.ID == id).FirstOrDefault();
                tien_ich.IsDelete = false;
                models.SaveChanges();
            }
            catch (Exception)
            {

            }

        }
        #endregion
        //Nhan Vien
        public int SoLuongDoan()
        {
            var lstDoan = nhanvien.LayDanhSachDoanTheoTrangThaiDatPhong(0);
            return lstDoan.Count();
        }
        public int SoLuongDoanDatPhongThanhCong()
        {
            var lstDoan = nhanvien.LayDanhSachDoanTheoTrangThaiDatPhong(1);
            return lstDoan.Count;
        }
        public int SoLuongKhachHangTrongDoan(string maDoan)
        {
            return models.KhachHangs.Where(kh => kh.MaDoan == maDoan).Count();
        }
        public int SoLuongDoanDatPhongThatBai()
        {
            DateTime today = DateTime.Now;
            var lstDoan = models.Doans.Where(d => d.TrangThaiDatPhong == -1 && d.IsDelete != true).ToList();
            //Xap xep danh sach doan theo ngay gui
            lstDoan = lstDoan.Where(d => d.ThoiGianTra.CompareTo(today) >= 0).OrderByDescending(d => d.NgayGui).ToList();

            return lstDoan.Count;
        }
        public int SoLuongPhongTheoDieuKien()
        {
            DateTime ngayNhan = new DateTime(2020, 8, 20);
            DateTime ngayTra = new DateTime(2020, 8, 20);
            NhanVienBusiness nhanvien = new NhanVienBusiness();
            return nhanvien.LayDanhSachPhongTheoDieuKien(ngayNhan, ngayTra).Count;

        }
        public int SoLuongKhachHangChungPhong()
        {
            return nhanvien.DanhSachKhachHangChungPhong(idPhong).Count;
        }
        public int SoLuongKhachHangChungPhongDichVuPhong()
        {
            return nhanvien.DanhSachKhachHangChungPhongDichVuPhong(idPhong).Count;
        }
        public int SoLuongThongTinChiPhiPhong()
        {
            if (nhanvien.LayThongTinChiPhiPhong(idPhong) != null)
                return nhanvien.LayThongTinChiPhiPhong(idPhong).Count;
            else
                return 0;
        }
        public int SoLuongLichSuDichVu()
        {
            return nhanvien.LayDSLichSuDichVu().Count;
        }
        public string TaoLichSuDichVu()
        {
            return "{\"IDPhong\":\"234\",\"SoPhong\":\"1234\",\"IDDichVu\":\"2\",\"TenDichVu\":\"Ăn uống\",\"NgayGoiDichVu\":\"2020/8/26\",\"GhiChu\":\"Giao đúng ngày\",\"IsDelete\":\"false\",\"IDKhachHang\":\"334\",\"HoVaTenKhachHang\":\"Nguyễn Đức Tuấn Anh\"}";
        }
        //Home
        public string ThongBaoLoi()
        {
            FileKhachHangDTO file = new FileKhachHangDTO();
            return home.LayFileDanhSachKhachHang(file.TenDoan, file.TenTruongDoan, file.ThoiGianNhan, file.ThoiGianTra, file.Files);
        }
        //Khach Hang
        public string CheckSoPhong()
        {
            string result = "ok";
            int count = 0;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong >= 0).Select(kh => new KhachHangDTO {
                ID = kh.ID,
                HoVaTen = kh.HoVaTen,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                DiaChi = kh.DiaChi,
                Nhom = kh.Nhom,
                NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm,
                ThoiGianNhan = kh.ThoiGianNhan,
                ThoiGianTra = kh.ThoiGianTra,
                MaDoan = kh.MaDoan,
                GioiTinh = kh.GioiTinh,
                LoaiKhachHang = kh.LoaiKhachHang,
                TruongDoan = kh.TruongDoan,
                IsDelete = kh.IsDelete,
                TrangThaiDatPhong = kh.TrangThaiDatPhong,
                IDPhong = kh.IDPhong,
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();
            var lstKeyMaDoan = lstKhachHang.GroupBy(s => s.MaDoan).Select(g => g.Key).ToList();
            for(int i = 0; i< lstKeyMaDoan.Count - 1; i++)
            {
                string key = lstKeyMaDoan[i];
                var lstKH = lstKhachHang.Where(kh => kh.MaDoan == key).ToList();
                for(int j = i+1; j < lstKeyMaDoan.Count - 1; j++)
                {
                    bool dk1 = false;
                    bool dk2 = false;
                    string key2 = lstKeyMaDoan[j];
                    var lstKh2 = lstKhachHang.Where(kh => kh.MaDoan == key2).ToList();
                    if (lstKh2[0].ThoiGianNhan.CompareTo(lstKH[0].ThoiGianNhan) >= 0 && lstKh2[0].ThoiGianNhan.CompareTo(lstKH[0].ThoiGianTra) <= 0)
                        dk1 = true;
                    if (lstKh2[0].ThoiGianNhan.CompareTo(lstKH[0].ThoiGianNhan) <= 0 && lstKh2[0].ThoiGianTra.CompareTo(lstKH[0].ThoiGianNhan) >= 0)
                        dk2 = true;
                    if (dk1 || dk2)
                    {
                        if (!KiemTraTrungPhong(lstKH, lstKh2))
                            result += key + "-" + key2 + "/";
                        count++;
                    }
                        
                }
            }
            return result;
        }

        private bool KiemTraTrungPhong(List<KhachHangDTO> lstKh1, List<KhachHangDTO> lstKH2)
        {
            bool b = true;
            foreach (var kh1 in lstKh1)
            {
                foreach (var kh2 in lstKH2)
                {
                    if (kh1.IDPhong == kh2.IDPhong)
                        return false;
                }
            }
            return b;
        }
    }
}
