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
        private int LaySoPhongTrong(List<KhachHangDTO> khachHangDTOs)
        {
            int soPhong = -1;
            return soPhong;
        }
        private bool KiemTraPhongTrong(List<KhachHangDTO> khachHangDTOs, int loaiPhong)
        {
            bool b = true;
            var lstPhong = models.Phongs.Where(p => p.LoaiPhong == loaiPhong).ToList();

            return b;
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
        private List<KhachHangDTO> XepPhongChoNhom(List<KhachHangDTO> khachHangDTOs, List<PhongDTO> phongDTOs, List<DatPhongThanhCongDTO> datPhongThanhCongDTOs)
        {
            int soThanhVien = TinhSoThanhVienNhom(khachHangDTOs);
            int idPhong = 0;
            DateTime thoiGianNhan = khachHangDTOs[0].ThoiGianNhan;
            DateTime thoiGianTra = khachHangDTOs[0].ThoiGianTra;
            if ( soThanhVien <= 4)
            {
                switch (soThanhVien)
                {
                    case 1: idPhong = LaySoPhongTrong(thoiGianNhan, thoiGianTra, 1, phongDTOs, datPhongThanhCongDTOs); break;
                    case 2: idPhong = LaySoPhongTrong(thoiGianNhan, thoiGianTra, 2, phongDTOs, datPhongThanhCongDTOs); break;
                    case 3: idPhong = LaySoPhongTrong(thoiGianNhan, thoiGianTra, 3, phongDTOs, datPhongThanhCongDTOs); break;
                    case 4: idPhong = LaySoPhongTrong(thoiGianNhan, thoiGianTra, 4, phongDTOs, datPhongThanhCongDTOs); break;
                }
                foreach (var item in khachHangDTOs)
                {
                    item.TrangThaiDatPhong = idPhong;
                }
            }
            return khachHangDTOs;
        }*/
        #endregion
    }
}