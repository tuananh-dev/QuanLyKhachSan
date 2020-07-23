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
            var lstKhachHangMaDoan = models.KhachHangs.Where(kh => kh.MaDoan.Equals(maDoan)).Select(kh => new KhachHangDTO
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
            var lstKhachHang = models.KhachHangs.Select(kh => new KhachHangDTO
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
                int loaiPhong = 0;
                var lstNhomKhachHang = lstKhachHangMaDoan.Where(kh => kh.Nhom == nhom).ToList();
                if (nhom == 0)
                {
                    loaiPhong = 1;
                    foreach (var khachHang in lstNhomKhachHang)
                    {
                        int idPhong = LaySoPhongTrong(lstKhachHang, lstPhong, loaiPhong, lstKhachHangMaDoan[0].ThoiGianNhan, lstKhachHangMaDoan[0].ThoiGianTra);
                        if (idPhong > 0)
                        {
                            khachHang.TrangThaiDatPhong = true;
                            khachHang.IDPhong = idPhong;
                            int index = lstKhachHangMaDoan.IndexOf(khachHang);
                            lstKhachHangMaDoan[index] = khachHang;
                            foreach (var phong in lstPhong)
                            {
                                if (phong.ID == idPhong)
                                    phong.TrangThai = false;
                            }
                        }
                        else
                            b = false;
                    }
                }
                else
                {
                    loaiPhong = TinhSoThanhVienNhom(lstNhomKhachHang);
                    if (loaiPhong <= 4)
                    {
                        int idPhong = LaySoPhongTrong(lstKhachHang, lstPhong, loaiPhong, lstKhachHangMaDoan[0].ThoiGianNhan, lstKhachHangMaDoan[0].ThoiGianTra);
                        if (idPhong > 0)
                        {
                            foreach (var khachHang in lstNhomKhachHang)
                            {
                                khachHang.TrangThaiDatPhong = true;
                                khachHang.IDPhong = idPhong;
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

            }
            LuuKhachHangDaDuocDatPhong(lstKhachHangMaDoan);
            models.SaveChanges();
            return b;
        }
        #endregion

        #region private methods
        private void LuuKhachHangDaDuocDatPhong(List<KhachHangDTO> khachHangDTOs)
        {
            string maDoan = khachHangDTOs[0].MaDoan;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.IsDelete != true && kh.MaDoan.Equals(maDoan)).ToList();
            for (int i = 0; i < lstKhachHang.Count; i++)
            {
                lstKhachHang[i].TrangThaiDatPhong = khachHangDTOs[i].TrangThaiDatPhong;
                lstKhachHang[i].IDPhong = khachHangDTOs[i].IDPhong;
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
            using (StreamWriter sw = new StreamWriter("C:\\Users\\TuA\\Documents\\1. VLU\\textfile.txt",true))
            {
                foreach (var item in lstKhachHang)
                {
                    if (item.LoaiKhachHang)
                        count++;

                    sw.WriteLine(count+"");
                }
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
                if (phong.TrangThai != false)
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
        #endregion

        /*using (StreamWriter sw = new StreamWriter("C:\\Users\\TuA\\Documents\\1. VLU\\textfile.txt"))
		  {
		    for(int i = 0; i<lstThuocTinh.Length;i++)
				sw.WriteLine(lstThuocTinh[i]+i);
          }*/
    }
}