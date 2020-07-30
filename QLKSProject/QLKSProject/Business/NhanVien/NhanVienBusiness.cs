using QLKSProject.Models.DTO;
using System;
using System.Collections.Generic;
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
        public string DatPhongThuNghiem(List<KhachHangDTO> khachHangDTOs)
        {
            string status = "ok";
            string maDoan = khachHangDTOs[0].MaDoan;

            try
            {
                var doan = models.Doans.Where(d => d.MaDoan == maDoan).FirstOrDefault();
                doan.TrangThaiDatPhong = 0;
                var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).ToList();
                foreach (var khachHang in lstKhachHang)
                {
                    var kh = khachHangDTOs.Where(k => k.ID == khachHang.ID).FirstOrDefault();
                    khachHang.HoVaTen = kh.HoVaTen;
                    khachHang.SoDienThoai = kh.SoDienThoai;
                    khachHang.Email = kh.Email;
                    khachHang.DiaChi = kh.DiaChi;
                    khachHang.Nhom = kh.Nhom;
                    khachHang.LoaiKhachHang = kh.LoaiKhachHang;
                    khachHang.NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm;
                    khachHang.GioiTinh = kh.GioiTinh;
                    khachHang.IDPhong = 0;
                }
                models.SaveChanges();
                status = DatPhong(maDoan);
            }
            catch (Exception)
            {
                status = "Lỗi đặt phòng!";
            }          
            return status;
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
                    IDPhong = kh.IDPhong,
                    TrangThaiXacNhan = kh.TrangThaiXacNhan
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
                            {
                                trangThaiDatPhong = "Không lấy được phòng cho khách hàng (Hết phòng) !!!";
                                khachHang.GhiChu = "Hết phòng/ Không có phòng phù hợp";
                            }
                                
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
                            {
                                trangThaiDatPhong = "Không lấy được số phòng cho khách !!!";
                                foreach (var khachHang in lstNhomKhachHang)
                                {
                                    khachHang.GhiChu = "Hết phòng/ Không có phòng phù hợp";
                                }
                            }                               
                        }
                        else
                        {
                            trangThaiDatPhong = "Số lượng thành viên trong nhóm quá 4 người !!!";
                            foreach (var khachHang in lstNhomKhachHang)
                            {
                                khachHang.GhiChu = "Số lượng thành viên trong nhóm quá 4 người !!!";
                            }
                        }
                            
                    }

                }
                if (trangThaiDatPhong.Equals("ok"))
                {
                    LuuDanhSachKhachHangDaDuocDatPhong(lstKhachHangMaDoan);
                    // Luu trang thai dat phong thanh cong cho Doan
                    doan.TrangThaiDatPhong = 1;
                    var khachHangDTO = lstKhachHangMaDoan.Where(kh => kh.TruongDoan == true).FirstOrDefault();
                    string account = RemoveUnicode(khachHangDTO.HoVaTen.ToLower().Replace(" ", ""));
                    string password = khachHangDTO.MaDoan.Substring(6);
                    if (!TaoTaiKhoanChoKhachHang(khachHangDTO, account, password))
                        trangThaiDatPhong = "Lỗi tạo tài khoản cho khách hàng !!!";
                    else
                    {
                        string subject = "Xác nhận đặt phòng tại Color Hotel";
                        string body = "Dear " + khachHangDTO.HoVaTen + ",<BR><BR>" + "Chúng tôi rất vui mừng vì bạn đã chọn khách sạn của chúng tôi. Danh sách khách hàng của quý khách đã được đặt phòng thành công!" + "<BR>Xin quý khách vui lòng đăng nhập bằng tài khoản và mật khẩu bên đưới để xác nhận.<BR>" + "Account: " + account + "<BR>" + "Password: " + password + "<BR>" + "<BR>Trân trọng,<BR>" + "Hotel Color";
                        string trangThaiGuiMail = GuiMailTuDong(account, subject, body);
                    }

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
        public string DatPhongChoNhieuDoan()
        {
            int soPhongThanhCong = 0;
            int soPhongThatBai = 0;
            var lstDoan = models.Doans.Where(d => d.TrangThaiDatPhong == 0).ToList();
            foreach (var doan in lstDoan)
            {
                string datPhong = DatPhong(doan.MaDoan);
                if (datPhong.Equals("ok"))
                    soPhongThanhCong++;
                else
                    soPhongThatBai++;                
            }
            string result = soPhongThanhCong + "-" + soPhongThatBai;
            return result;
        }
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
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();

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
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiXacNhan != false).Select(kh => new KhachHangDTO {
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
                        phong.TrangThai = false;
                }
            }
            return lstphong;
        }
        public List<DoanDTO> LayDanhSachDoanTheoTrangThaiDatPhong(int trangThaiDatPhong)
        {
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
            return lstDoan;
        }
        public List<PhongDTO> LayDanhSachPhongTheoDieuKien(DateTime ngayNhan, DateTime ngayTra)
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
            });
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
                TrangThaiXacNhan = kh.TrangThaiXacNhan
            }).ToList();
            foreach (var phong in lstphong)
            {
                var lstKhachHangPhong = lstKhachHang.Where(kh => kh.IDPhong == phong.ID).ToList();
                foreach (var kh in lstKhachHangPhong)
                {
                    if (kh.ThoiGianNhan.CompareTo(ngayNhan) <= 0 && kh.ThoiGianTra.CompareTo(ngayNhan) >= 1)
                        phong.TrangThai = false;
                    if (kh.ThoiGianNhan.CompareTo(ngayTra) <= 0 && kh.ThoiGianTra.CompareTo(ngayTra) >= 1)
                        phong.TrangThai = false;
                }
            }
            return lstphong.ToList();
        }
        public bool XoaDoan(string maDoan)
        {
            try
            {
                var doan = models.Doans.Where(d => d.MaDoan == maDoan).FirstOrDefault();
                doan.IsDelete = true;
                doan.TrangThaiDatPhong = 0;
                doan.TrangThaiXacNhan = false;
                return true;
                models.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            
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