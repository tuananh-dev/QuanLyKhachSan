using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QLKSProject.Models.Entities;

namespace QLKSProject.Business.NhanVien
{
    public class NhanVienBusiness : BaseBusiness
    {
        #region Public Methods
        public List<DoanDTO> LayDanhSachDoan()
        {
            var lstDoan = models.Doans.Where(s => s.TrangThaiDatPhong == 0).Select(s => new DoanDTO
            {
                ID = s.ID,
                MaDoan = s.MaDoan,
                TenDoan = s.TenDoan,
                NgayGui = s.NgayGui,
                TenTruongDoan = s.TenTruongDoan,
                ThoiGianNhan = s.ThoiGianNhan,
                ThoiGianTra = s.ThoiGianTra,
                IsDelete = s.IsDelete,
                TrangThaiDatPhong = s.TrangThaiDatPhong
            });
            return lstDoan.ToList();
        }
        public string DatPhong(string maDoan)
        {
            string trangThaiDatPhong = "ok";

            var doan = models.Doans.Where(d => d.MaDoan.Equals(maDoan)).FirstOrDefault();
            if (doan.TrangThaiDatPhong != 1)
            {
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
                if (lstPhong.Count == 0)
                    return trangThaiDatPhong = "Lỗi chưa tạo phòng!!!";
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
                                trangThaiDatPhong = "Khong lay duoc phong cho khach (Het Phong) !!!";
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
                                trangThaiDatPhong = "Không lấy được số phòng cho khách !!!";
                        }
                        else
                            trangThaiDatPhong = "Số lượng thành viên trong nhóm quá 4 người !!!";
                    }

                }
                if (trangThaiDatPhong.Equals("ok"))
                {
                    LuuDanhSachKhachHangDaDuocDatPhong(lstKhachHangMaDoan);
                    // Luu trang thai dat phong thanh cong cho Doan
                    doan.TrangThaiDatPhong = 1;
                    var khachHangDTO = lstKhachHang.Where(kh => kh.TruongDoan == true).FirstOrDefault();
                    if (!TaoTaiKhoanChoKhachHang(khachHangDTO))
                        trangThaiDatPhong = "Lỗi tạo tài khoản cho khách hàng !!!";
                }
                else
                {
                    // Luu trang thai dat phong that bai cho Doan
                    doan.TrangThaiDatPhong = -1;
                }
            }
            else
                trangThaiDatPhong = "Đoàn đặt phòng thành công đã tồn tại !!!";
            
            models.SaveChanges();
            return trangThaiDatPhong;
        }
        #endregion

        #region private methods
        private void LuuDanhSachKhachHangDaDuocDatPhong(List<KhachHangDTO> khachHangDTOs)
        {
            string maDoan = khachHangDTOs[0].MaDoan;
            var lstKhachHang = models.KhachHangs.Where(kh => kh.IsDelete != true && kh.MaDoan.Equals(maDoan)).ToList();
            for (int i = 0; i < lstKhachHang.Count; i++)
            {
                lstKhachHang[i].TrangThaiDatPhong = khachHangDTOs[i].TrangThaiDatPhong;
                lstKhachHang[i].IDPhong = khachHangDTOs[i].IDPhong;
            }
        }
        private bool TaoTaiKhoanChoKhachHang(KhachHangDTO khachHangDTO)
        {
            try
            {
                string account = RemoveUnicode(khachHangDTO.HoVaTen.ToLower().Replace(" ", ""));
                string password = khachHangDTO.MaDoan.Substring(6);
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TenTaiKhoan = account;
                taiKhoan.MatKhau = password;
                taiKhoan.HoVaTen = khachHangDTO.HoVaTen;
                taiKhoan.SoDienThoai = khachHangDTO.SoDienThoai;
                taiKhoan.Email = khachHangDTO.Email;
                taiKhoan.LoaiTaiKhoan = "nv";
                taiKhoan.IsDelete = false;
                models.TaiKhoans.Add(taiKhoan);
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
        private string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                                            "đ","é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ","í","ì","ỉ","ĩ","ị",
                                            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                                            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự","ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                                            "d","e","e","e","e","e","e","e","e","e","e","e","i","i","i","i","i",
                                            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                                            "u","u","u","u","u","u","u","u","u","u","u","y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
        #endregion

        /*using (StreamWriter sw = new StreamWriter("C:\\Users\\TuA\\Documents\\1. VLU\\textfile.txt"))
		  {
		    for(int i = 0; i<lstThuocTinh.Length;i++)
				sw.WriteLine(lstThuocTinh[i]+i);
          }*/
    }
}