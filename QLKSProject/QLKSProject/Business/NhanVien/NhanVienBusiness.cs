using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QLKSProject.Business.NhanVien
{
    public class NhanVienBusiness : BaseBusiness
    {
        #region Public Methods
        public List<DoanDTO> LayDanhSachDoan()
        {
            var lstDoan = models.Doans.Select(s => new DoanDTO
            {
                ID = s.ID,
                MaDoan = s.MaDoan,
                TenDoan = s.TenDoan,
                NgayGui = s.NgayGui,
                TenTruongDoan = s.TenTruongDoan,
                ThoiGianNhan = s.ThoiGianNhan,
                ThoiGianTra = s.ThoiGianTra,
                IsDelete = s.IsDelete,
            });
            return lstDoan.ToList();
        }
        public List<DatPhongThanhCongDTO> LayDanhSachDatPhongThanhCong()
        {
            var lstdatPhongThanhCongs = models.DatPhongThanhCongs.Select(s => new DatPhongThanhCongDTO
            {
                ID = s.ID,
                IDKhachHang = s.IDKhachHang,
                IDPhong = s.IDPhong,
                IsDelete = s.IsDelete,
                NgayTraPhongThucTe = s.NgayTraPhongThucTe
            });
            return lstdatPhongThanhCongs.ToList();
        }
        public List<DatPhongThatBaiDTO> LayDanhSachDatPhongThatBai()
        {
            var datPhongThatBais = models.DatPhongThatBais.Select(s => new DatPhongThatBaiDTO
            {
                ID = s.ID,
                TenDoan = s.TenDoan,
                MaDoan = s.MaDoan,
                IsDelete = s.IsDelete,
                GhiChu = s.GhiChu
            });
            return datPhongThatBais.ToList();
        }
        public bool DatPhong(string maDoan)
        {
            bool b = true;
            var lstKhachHangMaDoan = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).Select(kh => new KhachHangDTO
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
                IDPhong = kh.IDPhong
            }).ToList();
            var lstKhachHang = models.KhachHangs.Select(kh => new KhachHangDTO {
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
                IDPhong = kh.IDPhong
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
            List<int> lstNhom = LayDSNhomTrongDSKhachHang(lstKhachHangMaDoan);
            foreach (var nhom in lstNhom)
            {
                var lstNhomKhachHang = lstKhachHangMaDoan.Where(kh => kh.Nhom == nhom).ToList();
                int loaiPhong = TinhSoThanhVienNhom(lstNhomKhachHang);
                if (loaiPhong <= 4)
                {
                    int idPhong = LaySoPhongTrong(lstKhachHang, lstPhong, loaiPhong, lstKhachHangMaDoan[0].ThoiGianNhan, lstKhachHangMaDoan[0].ThoiGianTra);
                    if (idPhong > 0)
                    {
                        foreach (var khachHang in lstNhomKhachHang)
                        {
                            var kh = models.KhachHangs.Where(k => k.ID == khachHang.ID).FirstOrDefault();
                            kh.TrangThaiDatPhong = true;
                            kh.IDPhong = idPhong;
                            int index = lstKhachHangMaDoan.IndexOf(khachHang);
                            lstKhachHangMaDoan[index] = khachHang;
                            foreach (var phong in lstPhong)
                            {
                                if (phong.ID == idPhong)
                                    phong.TrangThai = false;
                            }
                        }
                    }
                    else
                        b = false;                   
                }
                else
                    b = false;
            }
            models.SaveChanges();
            return b;
        }
        #endregion

        #region private methods
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
                if (item.LoaiKhachHang.Equals("tre"))
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
                if (soTreEm == 2 || soTreEm == 1)
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
                if(phong.TrangThai != false)
                {
                    var lstKhachHang = khachHangDTOs.Where(kh => kh.IDPhong == phong.ID).ToList();
                    if (lstKhachHang.Count == 0)
                    {
                        soPhong = phong.ID;
                        break;
                    }
                    else
                    {
                        foreach (var khachHang in lstKhachHang)
                        {
                            int ngayNhanTTVoiNgaytra = ngayNhan.CompareTo(khachHang.ThoiGianTra);
                            int ngayTraTTVoiNgayNhan = ngayTra.CompareTo(khachHang.ThoiGianNhan);
                            if (ngayNhanTTVoiNgaytra > 0)
                            {
                                soPhong = phong.ID;
                                break;
                            }
                            if (ngayTraTTVoiNgayNhan < 0)
                            {
                                soPhong = phong.ID;
                                break;
                            }
                        }
                    }
                    if (soPhong > 0)
                        break;
                }
               
            }
            return soPhong;

        }
        private List<KhachHangDTO> XepPhongChoNhom(List<KhachHangDTO> khachHangDTOs, List<PhongDTO> phongDTOs, int soPhong)
        {
            int soThanhVien = TinhSoThanhVienNhom(khachHangDTOs);


            foreach (var item in khachHangDTOs)
            {
                item.IDPhong = soPhong;
                item.TrangThaiDatPhong = true;
            }

            return khachHangDTOs;
        }

        /* private int LaySoPhongTrong(DateTime ngayNhan, DateTime ngayTra, int loaiPhong, List<PhongDTO> phongDTOs, List<DatPhongThanhCongDTO> datPhongThanhCongDTOs)
        {
            int b = 0;
            if (KiemTraLoaiPhongTrong(ngayNhan, ngayTra, loaiPhong, phongDTOs, datPhongThanhCongDTOs))
            {
                var lstPhongLoaiPhong = phongDTOs.Where(p => p.IsDelete == false && p.LoaiPhong == loaiPhong).Select(p => p).ToList();
                foreach (var phong in lstPhongLoaiPhong)
                {
                    if (KiemTraPhongTrong(ngayNhan, ngayTra, phong.ID, datPhongThanhCongDTOs))
                        b = phong.ID;
                    break;
                }
            }
            return b;
        }
        private bool KiemTraPhongTrong(DateTime ngayNhan, DateTime ngayTra, int idPhong, List<DatPhongThanhCongDTO> lstDatPhongThanhCong)
        {
            bool b = true;
            var lstPhong = lstDatPhongThanhCong.Where(s => s.IDPhong == idPhong).Select(s => s).ToList();
            if (lstPhong != null)
                foreach (var item in lstPhong)
                {
                    var khachHang = models.KhachHangs.Where(s => s.ID == item.IDKhachHang).FirstOrDefault();
                    // kiem tra thoi gian nhan moi voi thoi gian nhan trong bang dang ky thanh cong
                    int nhanNhan = ngayNhan.CompareTo(khachHang.ThoiGianNhan);
                    // kiem tra thoi gian nhan moi voi thoi gian tra trong bang dang ky thanh cong
                    int nhanTra = ngayTra.CompareTo(khachHang.ThoiGianTra);
                    int traNhan = ngayTra.CompareTo(khachHang.ThoiGianNhan);
                    if (nhanNhan == -1 || nhanNhan == 0)
                        if (traNhan == 1 || traNhan == 0)
                            b = false;
                    if (nhanNhan == 1 || nhanNhan == 0)
                        if (nhanTra == -1 || nhanTra == 0)
                            b = false;
                }
            return b;
        }
        private bool KiemTraLoaiPhongTrong(DateTime ngayNhan, DateTime ngayTra, int loaiPhong, List<PhongDTO> phongDTOs, List<DatPhongThanhCongDTO> datPhongThanhCongDTOs)
        {
            bool b = false;
            int count = 0;
            var lstPhong = phongDTOs.Where(p => p.IsDelete == false && p.LoaiPhong == loaiPhong).Select(p => p).ToList();
            if (datPhongThanhCongDTOs.Count == 0)
                b = true;
            else
                foreach (var phong in lstPhong)
                {
                    foreach (var phongDatThanhCong in datPhongThanhCongDTOs)
                    {
                        if(phong.ID == phongDatThanhCong.ID)
                        {
                            if (KiemTraPhongTrong(ngayNhan, ngayTra, phong.ID, datPhongThanhCongDTOs))
                            {
                                b = true;
                                break;
                            } 
                        }else
                            count++;
                    }
                    if (b)
                        break;
                }
            if (count >= lstPhong.Count)
                b = true;
            return b;
        }
        */
        #endregion
    }
}