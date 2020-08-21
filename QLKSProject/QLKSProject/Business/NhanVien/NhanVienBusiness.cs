using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using QLKSProject.Models.Entities;


namespace QLKSProject.Business.NhanVien
{
    public class NhanVienBusiness : BaseBusiness
    {
        private string status_datphong;
        private int count_thanhcong = 0;
        private int count_thatbai = 0;
        
        #region Lay danh sach Doan, KhachHang, Phong, Xoa Doan    
        public List<KhachHangDTO> LayDanhSachKhachHangTheoMaDoan(string maDoan)
        {
            var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).Select(kh => new KhachHangDTO
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
                TrangThaiXacNhan = kh.TrangThaiXacNhan,
                GhiChu = kh.GhiChu
            }).ToList();
            //Xap xep khach hang theo nhom
            lstKhachHang = lstKhachHang.OrderBy(kh => kh.Nhom).ToList();
            return lstKhachHang;
        }
        public List<PhongDTO> LayDanhSachPhong()
        {
            DateTime today = DateTime.Now;
            var lstphong = models.Phongs.Where(e => e.IsDelete == false).Select(e => new PhongDTO
            {
                ID = e.ID,
                MaPhong = e.MaPhong,
                SoPhong = e.SoPhong,
                LoaiPhong = e.LoaiPhong,
                Gia = e.Gia,
                TrangThai = e.TrangThai,
                IsDelete = e.IsDelete
            }).ToList();
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiXacNhan != false).Select(kh => new KhachHangDTO
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
                TrangThaiXacNhan = kh.TrangThaiXacNhan,
                IDPhong = kh.IDPhong,
                GhiChu = kh.GhiChu
            }).ToList();
            foreach (var phong in lstphong)
            {
                var lstKhachHangPhong = lstKhachHang.Where(kh => kh.IDPhong == phong.ID).ToList();
                foreach (var kh in lstKhachHangPhong)
                {
                    if (kh.ThoiGianNhan.CompareTo(today) <= 0 && kh.ThoiGianTra.CompareTo(today) >= 1)
                        phong.TrangThai = kh.TrangThaiDatPhong;
                }
            }
            return lstphong;
        }
        public List<DoanDTO> LayDanhSachDoanTheoTrangThaiDatPhong(int trangThaiDatPhong)
        {
            DateTime today = DateTime.Now;
            var lstDoan = models.Doans.Where(d => d.TrangThaiDatPhong == trangThaiDatPhong && d.IsDelete != true).Select(d => new DoanDTO
            {
                ID = d.ID,
                MaDoan = d.MaDoan,
                TenDoan = d.TenDoan,
                NgayGui = d.NgayGui,
                TenTruongDoan = d.TenTruongDoan,
                ThoiGianNhan = d.ThoiGianNhan,
                ThoiGianTra = d.ThoiGianTra,
                IsDelete = d.IsDelete,
                TrangThaiDatPhong = d.TrangThaiDatPhong,
                TrangThaiXacNhan = d.TrangThaiXacNhan
            }).ToList();
            //Xap xep danh sach doan theo ngay gui cho doan dat phong that bai
            if (trangThaiDatPhong != 1)
                lstDoan = lstDoan.Where(d => d.ThoiGianTra.CompareTo(today) >= 0).ToList();
            lstDoan = lstDoan.OrderByDescending(d => d.NgayGui).ToList();
            return lstDoan;
        }
        public List<string> LayDanhSachPhongTheoDieuKien(DateTime ngayNhan, DateTime ngayTra)
        {
            var lstphong = models.Phongs.Where(e => e.IsDelete == false).Select(e => new PhongDTO
            {
                ID = e.ID,
                MaPhong = e.MaPhong,
                SoPhong = e.SoPhong,
                LoaiPhong = e.LoaiPhong,
                Gia = e.Gia,
                TrangThai = e.TrangThai,
                IsDelete = e.IsDelete
            }).ToList();
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong >= 0).Select(kh => new KhachHangDTO
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
                TrangThaiXacNhan = kh.TrangThaiXacNhan,
                IDPhong = kh.IDPhong
            }).ToList();
            foreach (var phong in lstphong)
            {
                var lstKhachHangPhong = lstKhachHang.Where(kh => kh.IDPhong == phong.ID).ToList();
                foreach (var kh in lstKhachHangPhong)
                {
                    if (kh.ThoiGianNhan.CompareTo(ngayNhan) <= 0 && kh.ThoiGianTra.CompareTo(ngayNhan) >= 0)
                        phong.TrangThai = 1;
                    if (kh.ThoiGianNhan.CompareTo(ngayTra) <= 0 && kh.ThoiGianTra.CompareTo(ngayNhan) >= 0)
                        phong.TrangThai = 1;
                }
            }
            List<string> dsLoaiPhongTrong = new List<string>();
            var lstLoaiPhong = lstphong.GroupBy(p => p.LoaiPhong).ToList();
            foreach (var dsPhong in lstLoaiPhong)
            {
                int count = 0;
                string loaiPhong = "";
                foreach (var p in dsPhong)
                {
                    loaiPhong = p.LoaiPhong.ToString();
                    if (p.TrangThai <= 0)
                        count++;                
                }
                dsLoaiPhongTrong.Add(loaiPhong + "-" + count);
            }
            return dsLoaiPhongTrong;
        }
        public bool XoaDoan(string maDoan)
        {
            bool b = XoaDoanTheoMaDoan(maDoan);
            models.SaveChanges();
            return b;
        }
        #endregion

        #region Dat Phong, Tra Phong, Nhan Phong
        public string DatPhongThuNghiem(List<KhachHangDTO> khachHang_MotDoanDTOs)
        {
            string status = "ok";
            string maDoan = khachHang_MotDoanDTOs[0].MaDoan;
            DateTime today = DateTime.Today;
            if (khachHang_MotDoanDTOs[0].ThoiGianNhan.CompareTo(today) < 0)
                return "Thời gian nhận phòng nhỏ hơn thời gian hiện tại";
            var lstKhachHangDTO = models.KhachHangs.Where(kh => kh.IsDelete != true && kh.ThoiGianTra.CompareTo(today) >= 0).Select(kh => new KhachHangDTO
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
            var lstPhongDTO = models.Phongs.Where(p => p.IsDelete != true).Select(p => new PhongDTO
            {
                ID = p.ID,
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.LoaiPhong,
                Gia = p.Gia,
                TrangThai = p.TrangThai,
                IsDelete = p.IsDelete
            }).ToList();
            try
            { 
                var lstKhachHang = lstKhachHangDTO.Where(kh => kh.MaDoan == maDoan).ToList();
                foreach (var khachHang in lstKhachHang)
                {
                    var kh = khachHang_MotDoanDTOs.Where(k => k.ID == khachHang.ID).FirstOrDefault();
                    khachHang.HoVaTen = kh.HoVaTen;
                    khachHang.SoDienThoai = kh.SoDienThoai;
                    khachHang.Email = kh.Email;
                    khachHang.DiaChi = kh.DiaChi;
                    khachHang.Nhom = kh.Nhom;
                    khachHang.LoaiKhachHang = kh.LoaiKhachHang;
                    khachHang.NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm;
                    khachHang.GioiTinh = kh.GioiTinh;
                    khachHang.IDPhong = 0;
                    khachHang.GhiChu = "";
                    khachHang.ThoiGianNhan = kh.ThoiGianNhan;
                    khachHang.ThoiGianTra = kh.ThoiGianTra;
                }
                status = DatPhongChoMotDoanKhachHang(maDoan,lstKhachHangDTO,lstPhongDTO);
                if(status.Equals("ok"))
                    models.SaveChanges();
            }
            catch (Exception)
            {
                status = "Lỗi đặt phòng!";
            }
            return status;
        }
        public string KhachHangTraPhong(string cmnd)
        {
            string status = "ok";
            try
            {
                DateTime today = DateTime.Now;
                var khachHang = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong == 1 && kh.GhiChu.Equals(cmnd)).FirstOrDefault();
                var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == khachHang.MaDoan && kh.Nhom == khachHang.Nhom).ToList();
                foreach (var kh in lstKhachHang)
                {
                    kh.ThoiGianTra = today;
                    kh.TrangThaiDatPhong = -2;
                    if (kh.GhiChu != null)
                        kh.GhiChu = "Da tra phong";
                }
                models.SaveChanges();
            }
            catch (Exception)
            {
                status = "Trả phòng thất bại!";
            }

            return status;
        }
        public string KhachHangNhanPhong(int idPhong, string hovaten, string cmnd)
        {
            string status = "ok";
            try
            {
                DateTime today = DateTime.Now;
                var lstKhachHang = models.KhachHangs.Where(kh => kh.IDPhong == idPhong && kh.TrangThaiDatPhong == 0).ToList();
                lstKhachHang = lstKhachHang.Where(kh => kh.ThoiGianNhan.CompareTo(today) <= 0 && kh.ThoiGianTra.CompareTo(today) >= 0).ToList();
                var nguoiDaiDien = lstKhachHang.Where(kh => kh.HoVaTen.Equals(hovaten)).FirstOrDefault();
                nguoiDaiDien.GhiChu = cmnd;
                if (lstKhachHang.Count != 0)
                {
                    foreach (var kh in lstKhachHang)
                    {
                        kh.TrangThaiDatPhong = 1;
                    }
                    models.SaveChanges();
                }
                else
                    status = "Lỗi nhận phòng!";


            }
            catch (Exception)
            {
                status = "Lỗi lưu CSDL!";
            }

            return status;
        }
        public List<KhachHangDTO> DanhSachKhachHangChungPhong(int idPhong)
        {
            DateTime today = DateTime.Now;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.IDPhong == idPhong && kh.ThoiGianNhan.CompareTo(today) <= 0 && kh.ThoiGianTra.CompareTo(today) >= 0).Select(kh => new KhachHangDTO
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
            return lstKhachHang;
        }
        public List<string> LayThongTinChiPhiPhong(int idPhong)
        {
            List<string> thongTinChiPhiPhong = new List<string>();
            DateTime today = DateTime.Now;
            var khachHang = models.KhachHangs.Where(kh => kh.IDPhong == idPhong && kh.ThoiGianNhan.CompareTo(today) <= 0 && kh.ThoiGianTra.CompareTo(today) >= 0 && kh.GhiChu != null).FirstOrDefault();
            if (khachHang == null)
                return null;
            thongTinChiPhiPhong.Add(khachHang.HoVaTen);
            thongTinChiPhiPhong.Add(khachHang.GhiChu);
            var lstPhongDichVu = models.LichSuDichVus.Where(p => p.IDPhong == idPhong && khachHang.ThoiGianNhan.CompareTo(p.NgayGoiDichVu) <= 0 && khachHang.ThoiGianTra.CompareTo(p.NgayGoiDichVu) >= 0).ToList();
            string thongTinChiPhi = "";
            int tongChiPhi = 0;
            foreach (var dv in lstPhongDichVu)
            {
                tongChiPhi += LayGiaDV(dv.TenDichVu);
                thongTinChiPhi = dv.TenDichVu + "-" + dv.HoVaTenKhachHang + "-" + LayGiaDV(dv.TenDichVu);
                thongTinChiPhiPhong.Add(thongTinChiPhi);
            }
            thongTinChiPhiPhong.Add(tongChiPhi.ToString());
            return thongTinChiPhiPhong;
        }
        public string DatPhongChoMotDoan(string maDoan)
        {
            DateTime today = DateTime.Now;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.IsDelete != true && kh.ThoiGianTra.CompareTo(today) >= 0).Select(kh => new KhachHangDTO
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
            var lstPhong = models.Phongs.Where(p => p.IsDelete != true).Select(p => new PhongDTO
            {
                ID = p.ID,
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.LoaiPhong,
                Gia = p.Gia,
                TrangThai = p.TrangThai,
                IsDelete = p.IsDelete
            }).ToList();
            string status = DatPhongChoMotDoanKhachHang(maDoan, lstKhachHang, lstPhong);
            models.SaveChanges();
            return status;
        }
        public string DatPHongNhieuDoanKhachHang()
        {
            count_thanhcong = 0;
            count_thatbai = 0;
            DateTime today = DateTime.Today;
            var lstDoan = models.Doans.Where(d => d.TrangThaiDatPhong == 0 && d.ThoiGianNhan.CompareTo(today) >= 0).Select(d => new DoanDTO {
                ID = d.ID,
                MaDoan = d.MaDoan,
                TenDoan = d.TenDoan,
                NgayGui = d.NgayGui,
                TenTruongDoan = d.TenTruongDoan,
                ThoiGianNhan = d.ThoiGianNhan,
                ThoiGianTra = d.ThoiGianTra,
                IsDelete = d.IsDelete,
                TrangThaiDatPhong = d.TrangThaiDatPhong,
                TrangThaiXacNhan = d.TrangThaiXacNhan
            }).ToList();
            var lstKhachHang = models.KhachHangs.Where(kh => kh.IsDelete != true && kh.ThoiGianTra.CompareTo(today) >= 0).Select(kh => new KhachHangDTO
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
            var lstPhong = models.Phongs.Where(p => p.IsDelete != true).Select(p => new PhongDTO
            {
                ID = p.ID,
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                LoaiPhong = p.LoaiPhong,
                Gia = p.Gia,
                TrangThai = p.TrangThai,
                IsDelete = p.IsDelete
            }).ToList();
            string status = DatPhongChoNhieuDoanKhachHang(lstDoan, lstKhachHang, lstPhong);
            models.SaveChanges();
            return count_thanhcong+"-"+count_thatbai;
        }
        #endregion

        #region DichVuPhong
        public List<KhachHangDTO> DanhSachKhachHangChungPhongDichVuPhong(int idPhong)
        {
            DateTime today = DateTime.Now;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.IDPhong == idPhong && kh.ThoiGianNhan.CompareTo(today) <= 0 && kh.ThoiGianTra.CompareTo(today) >= 0).Select(kh => new KhachHangDTO
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
            lstKhachHang = lstKhachHang.Where(kh => kh.TrangThaiDatPhong == 1).ToList();
            return lstKhachHang;
        }
        public List<LichSuDichVuDTO> LayDSLichSuDichVu()
        {
            var lstLichSuDichVu = models.LichSuDichVus.Where(l => l.IsDelete != true).Select(l => new LichSuDichVuDTO
            {
                ID = l.ID,
                IDPhong = l.IDPhong,
                SoPhong = l.SoPhong,
                IDDichVu = l.IDDichVu,
                TenDichVu = l.TenDichVu,
                NgayGoiDichVu = l.NgayGoiDichVu,
                GhiChu = l.GhiChu,
                IsDelete = l.IsDelete,
                IDKhachHang = l.IDKhachHang,
                HoVaTenKhachHang = l.HoVaTenKhachHang
            }).ToList();
            lstLichSuDichVu = lstLichSuDichVu.OrderBy(d => d.NgayGoiDichVu).ToList();
            return lstLichSuDichVu;
        }
        public bool ThemMoiDichVuPhong(LichSuDichVuDTO dichVuPhong)
        {
            DateTime today = DateTime.Now;
            try
            {
                LichSuDichVu lichSuDichVu = new LichSuDichVu();
                lichSuDichVu.IDDichVu = dichVuPhong.IDDichVu;
                lichSuDichVu.IDKhachHang = dichVuPhong.IDKhachHang;
                lichSuDichVu.IDPhong = dichVuPhong.IDPhong;
                lichSuDichVu.IsDelete = false;
                lichSuDichVu.NgayGoiDichVu = today;
                lichSuDichVu.SoPhong = dichVuPhong.SoPhong;
                lichSuDichVu.TenDichVu = dichVuPhong.TenDichVu;
                lichSuDichVu.HoVaTenKhachHang = dichVuPhong.HoVaTenKhachHang;
                lichSuDichVu.GhiChu = dichVuPhong.GhiChu;
                models.LichSuDichVus.Add(lichSuDichVu);
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public string XoaDichVuPhong(int id)
        {
            string status = "ok";
            var dichVuPhong = models.LichSuDichVus.Where(d => d.ID == id).FirstOrDefault();
            try
            {
                if (dichVuPhong == null)
                    status = "Không tìm thấy lịch sử dịch vụ của đối tượng được chọn!!!";
                else
                {
                    dichVuPhong.IsDelete = true;
                    models.SaveChanges();
                }
            }
            catch (Exception)
            {
                status = "Lỗi không xóa được Lịch sử dịch vụ!!!";
            }
            return status;
        }
        public List<DichVuDTO> LayDanhSachDichVu()
        {
            var lstdichvu = models.DichVus.Where(e => e.IsDelete == false).Select(e => new DichVuDTO
            {
                ID = e.ID,
                TenDichVu = e.TenDichVu,
                Gia = e.Gia,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            });
            return lstdichvu.ToList();
        }
        #endregion

        #region private methods
        private void LuuDanhSachKhachHangDatPhongThanhCong(List<KhachHangDTO> khachHangDTOs)
        {
            string maDoan = khachHangDTOs[0].MaDoan;
            var doan = models.Doans.Where(d => d.MaDoan.Equals(maDoan)).FirstOrDefault();
            doan.TrangThaiDatPhong = 1;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan.Equals(maDoan)).ToList();
            for (int i = 0; i < lstKhachHang.Count; i++)
            {
                lstKhachHang[i].TrangThaiDatPhong = khachHangDTOs[i].TrangThaiDatPhong;
                lstKhachHang[i].IDPhong = khachHangDTOs[i].IDPhong;
                lstKhachHang[i].GhiChu = "Đặt phòng thành công";
            }
        }
        private void LuuDanhSachKhachHangDatPhongThatBai(List<KhachHangDTO> khachHangDTOs)
        {
            string maDoan = khachHangDTOs[0].MaDoan;
            var doan = models.Doans.Where(d => d.MaDoan.Equals(maDoan)).FirstOrDefault();
            doan.TrangThaiDatPhong = -1;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan.Equals(maDoan)).ToList();
            for (int i = 0; i < lstKhachHang.Count; i++)
            {
                if (khachHangDTOs[i].GhiChu != null)
                    lstKhachHang[i].GhiChu = khachHangDTOs[i].GhiChu;

                lstKhachHang[i].IDPhong = -1;
                lstKhachHang[i].TrangThaiDatPhong = -1;
            }
        }

        private bool TaoTaiKhoanChoKhachHang(KhachHangDTO khachHangDTO, string account, string password)
        {
            try
            {
                UserMaster taiKhoan = new UserMaster();
                taiKhoan.UserName = account;
                taiKhoan.UserPassword = password;
                taiKhoan.FullName = khachHangDTO.HoVaTen;
                taiKhoan.PhoneNumber = khachHangDTO.SoDienThoai;
                taiKhoan.UserEmailID = khachHangDTO.Email;
                taiKhoan.UserRoles = "kh";
                taiKhoan.IsDelete = false;
                taiKhoan.UserID = khachHangDTO.ID;
                taiKhoan.MaDoan = khachHangDTO.MaDoan;
                models.UserMasters.Add(taiKhoan);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        private List<int> LayDSNhomTrongDSKhachHang(List<KhachHangDTO> lstKhachHang)
        {
            var lstNhom = lstKhachHang.GroupBy(s => s.Nhom).Select(g => g.Key).ToList();
            return lstNhom;
        }
        private int KiemTraTreEmCoTrongDanhSach(List<KhachHangDTO> lstKhachHang)
        {
            int count = 0;
            foreach (var item in lstKhachHang)
            {
                if (item.LoaiKhachHang)
                    count++;
            }
            return count;
        }

        private int TinhSoThanhVienNhom(List<KhachHangDTO> khachHangDTOs)
        {
            int count = khachHangDTOs.Count;
            int soTreEm = KiemTraTreEmCoTrongDanhSach(khachHangDTOs);
            if (soTreEm == 3)
            {
                count = khachHangDTOs.Count - 1;
            }
            else
            {
                if (soTreEm == 2)
                {
                    count = khachHangDTOs.Count - 2;
                }
            }
            return count;
        }
        private int LaySoPhongTrong(List<KhachHangDTO> khachHangDTOs, List<PhongDTO> phongDTOs, int loaiPhong, DateTime ngayNhan, DateTime ngayTra)
        {
            int soPhong = -1;
            //Kiem tra phong trong
            var lstPhong = phongDTOs.Where(p => p.LoaiPhong == loaiPhong).ToList();
            foreach (var phong in lstPhong)
            {
                if (phong.TrangThai < 0)
                {
                    var lstKhachHang = khachHangDTOs.Where(kh => kh.IDPhong == phong.ID).ToList();
                    if (lstKhachHang.Count == 0)
                    {
                        soPhong = phong.ID;
                        break;
                    }
                    else
                    {
                        int count = 0;
                        foreach (var khachHang in lstKhachHang)
                        {
                            if (phong.TrangThai < 0)
                            {
                                int ngayNhanTTVoiNgaytra = ngayNhan.CompareTo(khachHang.ThoiGianTra);
                                int ngayTraTTVoiNgayNhan = ngayTra.CompareTo(khachHang.ThoiGianNhan);
                                if (ngayNhanTTVoiNgaytra > 0 || ngayTraTTVoiNgayNhan < 0)
                                {
                                    count++;
                                }
                                else
                                {
                                    phong.TrangThai = 0;
                                    break;
                                }
                            }                           
                        }
                        if (count == lstKhachHang.Count)
                        {
                            soPhong = phong.ID;
                            break;
                        }
                            
                    }
                    if (soPhong > 0)
                        break;
                }

            }
            return soPhong;

        }
        private int LayGiaDV(string tenDv)
        {
            return models.DichVus.Where(d => d.TenDichVu.Equals(tenDv)).Select(d => d.Gia).FirstOrDefault();
        }
        private bool XoaDoanTheoMaDoan(string maDoan)
        {
            bool b = true;
            try
            {
                var doan = models.Doans.Where(d => d.MaDoan == maDoan).FirstOrDefault();
                doan.IsDelete = true;
                doan.TrangThaiDatPhong = 0;
                doan.TrangThaiXacNhan = false;
                var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan.Equals(maDoan)).ToList();
                foreach (var kh in lstKhachHang)
                {
                    kh.IsDelete = true;
                    kh.GhiChu = "Nhân viên xóa đoàn";
                    kh.IDPhong = -2;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return b;
        }
        private string DatPhongChoMotDoanKhachHang(string maDoan, List<KhachHangDTO> khachHangDTOs, List<PhongDTO> phongDTOs)
        {
            status_datphong = "ok";
            var lstKHMotDoan = khachHangDTOs.Where(kh => kh.MaDoan.Equals(maDoan)).ToList();
            if (lstKHMotDoan.Count <= 0)
                return status_datphong = "Đoàn cần đặt phòng không tồn tại!";
            var lstKey = lstKHMotDoan.GroupBy(s => s.Nhom).ToList();
            var loaiPhongMax = phongDTOs.OrderByDescending(p => p.LoaiPhong).Select(p => p.LoaiPhong).FirstOrDefault();
            int loaiPhong = 0;
            DateTime thoiGianNhan = lstKHMotDoan[0].ThoiGianNhan;
            DateTime thoiGianTra = lstKHMotDoan[0].ThoiGianTra;
            foreach (var key in lstKey)
            {
                //Lay loai phong
                if (key.Key == 0)
                    loaiPhong = 1;
                else
                    loaiPhong = TinhSoThanhVienNhom(key.ToList());
                //Kiem tra so nguoi voi loai phong
                if (loaiPhong > loaiPhongMax)
                {
                    status_datphong = "Không có loại phòng phù hợp";
                    foreach (var kh in key)
                    {
                        kh.GhiChu = "Không có loại phòng phù hợp";
                    }
                }
                else
                {
                    //Lay so phong cho nhom
                    int idPhong = LaySoPhongTrong(khachHangDTOs, phongDTOs, loaiPhong, thoiGianNhan, thoiGianTra);
                    if (idPhong > 0)
                    {
                        //gan so phong cho nhom
                        foreach (var kh in key)
                        {
                            kh.TrangThaiDatPhong = 0;
                            kh.IDPhong = idPhong;
                            //doi trang thai cua phongDTOs
                            var phong = phongDTOs.Where(p => p.ID == idPhong).FirstOrDefault();
                            phong.TrangThai = 0;

                        }
                    }
                    else
                    {
                        //Thong bao loi va luu thong bao loi vao khacHangDTOs
                        status_datphong = "Không lấy được số phòng của loại phòng <" + loaiPhong + "> cho khách !!!";
                        foreach (var kh in key)
                        {
                            kh.GhiChu = "Hết phòng loại <" + loaiPhong + ">";
                        }
                    }
                }

            }
            if (status_datphong.Equals("ok"))
            {
                LuuDanhSachKhachHangDatPhongThanhCong(lstKHMotDoan);
                //gui mail
                var khachHangDTO = lstKHMotDoan.Where(kh => kh.TruongDoan == true).FirstOrDefault();
                string account = RemoveUnicode(khachHangDTO.HoVaTen.ToLower().Replace(" ", ""));
                string password = khachHangDTO.MaDoan.Substring(6);
                if (!TaoTaiKhoanChoKhachHang(khachHangDTO, account, password))
                    khachHangDTO.GhiChu = "Đặt phòng thành công nhưng không tạo được tài khoản cho khách hàng!!!";
                else
                {
                    string subject = "Xác nhận đặt phòng tại Color Hotel";
                    string body = "Dear " + khachHangDTO.HoVaTen + ",<BR><BR>" + "Chúng tôi rất vui mừng vì bạn đã chọn khách sạn của chúng tôi. Danh sách khách hàng của quý khách đã được đặt phòng thành công!" + "<BR>Xin quý khách vui lòng đăng nhập bằng tài khoản và mật khẩu bên đưới để xác nhận.<BR>" + "Account: " + account + "<BR>" + "Password: " + password + "<BR>" + "<BR>Trân trọng,<BR>" + "Hotel Color";
                    string trangThaiGuiMail = GuiMailTuDong(khachHangDTO.Email, subject, body);
                    khachHangDTO.GhiChu = trangThaiGuiMail;
                }
            }
            else
            {
                LuuDanhSachKhachHangDatPhongThatBai(lstKHMotDoan);
            }
            return status_datphong;
        }
        private string DatPhongChoNhieuDoanKhachHang(List<DoanDTO> doanDTOs, List<KhachHangDTO> khachHangDTOs, List<PhongDTO> phongDTOs)
        {
            status_datphong = "ok";
            var madoan = doanDTOs.Where(d => d.TrangThaiDatPhong == 0).Select(d => d.MaDoan).FirstOrDefault();
            if (madoan != null)
            {
                var lstKHMotDoan = khachHangDTOs.Where(kh => kh.MaDoan.Equals(madoan)).ToList();
                if(lstKHMotDoan.Count > 0)
                {
                    var lstKey = lstKHMotDoan.GroupBy(s => s.Nhom).ToList();
                    var loaiPhongMax = phongDTOs.OrderByDescending(p => p.LoaiPhong).Select(p => p.LoaiPhong).FirstOrDefault();
                    int loaiPhong = 0;
                    DateTime thoiGianNhan = lstKHMotDoan[0].ThoiGianNhan;
                    DateTime thoiGianTra = lstKHMotDoan[0].ThoiGianTra;
                    foreach (var key in lstKey)
                    {
                        //Lay loai phong
                        if (key.Key == 0)
                            loaiPhong = 1;
                        else
                            loaiPhong = TinhSoThanhVienNhom(key.ToList());
                        //Kiem tra so nguoi voi loai phong
                        if (loaiPhong > loaiPhongMax)
                        {
                            status_datphong = "Không có loại phòng phù hợp";
                            foreach (var kh in key)
                            {
                                kh.GhiChu = "Không có loại phòng phù hợp";
                            }
                        }
                        else
                        {
                            //Lay so phong cho nhom
                            int idPhong = LaySoPhongTrong(khachHangDTOs, phongDTOs, loaiPhong, thoiGianNhan, thoiGianTra);
                            if (idPhong > 0)
                            {
                                //gan so phong cho nhom
                                foreach (var kh in key)
                                {
                                    kh.TrangThaiDatPhong = 0;
                                    kh.IDPhong = idPhong;
                                    //doi trang thai cua phongDTOs
                                    var phong = phongDTOs.Where(p => p.ID == idPhong).FirstOrDefault();
                                    phong.TrangThai = 0;
                                }
                            }
                            else
                            {
                                //Thong bao loi va luu thong bao loi vao khacHangDTOs
                                status_datphong = "Không lấy được số phòng của loại phòng <" + loaiPhong + "> cho khách !!!";
                                foreach (var kh in key)
                                {                          
                                    kh.GhiChu = "Hết phòng loại <" + loaiPhong + ">";
                                }
                            }
                        }
                        
                    }
                    if (status_datphong.Equals("ok"))
                    {
                        LuuDanhSachKhachHang(lstKHMotDoan, true);
                        count_thanhcong++;
                        //gui mail
                        var khachHangDTO = lstKHMotDoan.Where(kh => kh.TruongDoan == true).FirstOrDefault();
                        string account = RemoveUnicode(khachHangDTO.HoVaTen.ToLower().Replace(" ", ""));
                        string password = khachHangDTO.MaDoan.Substring(6);
                        if (!TaoTaiKhoanChoKhachHang(khachHangDTO, account, password))
                            khachHangDTO.GhiChu = "Đặt phòng thành công nhưng không tạo được tài khoản cho khách hàng!!!";
                        else
                        {
                            string subject = "Xác nhận đặt phòng tại Color Hotel";
                            string body = "Dear " + khachHangDTO.HoVaTen + ",<BR><BR>" + "Chúng tôi rất vui mừng vì bạn đã chọn khách sạn của chúng tôi. Danh sách khách hàng của quý khách đã được đặt phòng thành công!" + "<BR>Xin quý khách vui lòng đăng nhập bằng tài khoản và mật khẩu bên đưới để xác nhận.<BR>" + "Account: " + account + "<BR>" + "Password: " + password + "<BR>" + "<BR>Trân trọng,<BR>" + "Hotel Color";
                            string trangThaiGuiMail = GuiMailTuDong(khachHangDTO.Email, subject, body);
                            khachHangDTO.GhiChu = trangThaiGuiMail;
                        }
                        var doan = doanDTOs.Where(d => d.MaDoan == madoan).FirstOrDefault();
                        doan.TrangThaiDatPhong = 1;
                    }
                    else
                    {
                        LuuDanhSachKhachHang(lstKHMotDoan, false);
                        count_thatbai++;
                        var doan = doanDTOs.Where(d => d.MaDoan == madoan).FirstOrDefault();
                        doan.TrangThaiDatPhong = -1;
                    }
                    //Khoi tao lai trang thai phong ve ban dau
                    foreach (var phong in phongDTOs)
                    {
                        phong.TrangThai = -1;
                    }
                }
                else
                {
                    var doan = doanDTOs.Where(d => d.MaDoan == madoan).FirstOrDefault();
                    doan.TrangThaiDatPhong = -1;
                }

                LuuThongTinDoan(madoan,doanDTOs);
                return DatPhongChoNhieuDoanKhachHang(doanDTOs, khachHangDTOs, phongDTOs);
            }           
            return status_datphong;
        }
        private void LuuDanhSachKhachHang(List<KhachHangDTO> khachHangDTOs, bool status)
        {
            DateTime today = DateTime.Now;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.IsDelete != true && kh.ThoiGianTra.CompareTo(today) >= 0).ToList();
            foreach (var kh in khachHangDTOs)
            {
                var khachHang = lstKhachHang.Where(k => k.ID == kh.ID).FirstOrDefault();
                if(khachHang != null)
                {
                    if (status)
                    {
                        khachHang.TrangThaiDatPhong = kh.TrangThaiDatPhong;
                        khachHang.IDPhong = kh.IDPhong;
                        khachHang.GhiChu = kh.GhiChu;
                    }
                    else
                    {
                        khachHang.TrangThaiDatPhong = -1;
                        khachHang.IDPhong = -1;
                        khachHang.GhiChu = kh.GhiChu;
                    }
                    
                }
                
            }
        }
        private void LuuThongTinDoan(string madoan,List<DoanDTO> doanDTOs)
        {
            var doanDTO = doanDTOs.Where(d => d.MaDoan == madoan).FirstOrDefault();
            var doan = models.Doans.Where(d => d.MaDoan == madoan).FirstOrDefault();
            doan.TrangThaiDatPhong = doanDTO.TrangThaiDatPhong;
        }
        
        #endregion
    }
}