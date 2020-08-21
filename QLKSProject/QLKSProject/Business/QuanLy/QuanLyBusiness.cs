using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using QLKSProject.Models.DTO;
using QLKSProject.Models.Entities;

namespace QLKSProject.Business.QuanLy
{
    public class QuanLyBusiness : BaseBusiness
    {
        #region UserMaster
        public List<UserMasterDTO> LayDanhSachTaiKhoan()
        {
            var lstUserMaster = models.UserMasters.Where(e => e.IsDelete == false && e.UserRoles == "NV").Select(e => new UserMasterDTO
            {
                ID = e.ID,
                UserName = e.UserName,
                UserPassword = e.UserPassword,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                UserEmailID = e.UserEmailID,
                UserRoles = e.UserRoles,
                IsDelete = e.IsDelete
            });
            return lstUserMaster.ToList();
        }
        public UserMasterDTO LayTaiKhoan(int idUserMaster)
        {

            var UserMaster = models.UserMasters.Where(e => e.ID == idUserMaster).Select(e => new UserMasterDTO
            {
                ID = e.ID,
                UserName = e.UserName,
                UserPassword = e.UserPassword,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                UserEmailID = e.UserEmailID,
                UserRoles = e.UserRoles,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return UserMaster;
        }
        public bool ThemTaiKhoan(UserMasterDTO userMaster)
        {
            UserMaster tk = new UserMaster();
            if (CheckUserMaster(userMaster.UserName))
            {
                tk.UserName = userMaster.UserName;
                tk.UserPassword = userMaster.UserPassword;
                tk.UserRoles = userMaster.UserRoles;
                tk.FullName = userMaster.FullName;
                tk.PhoneNumber = userMaster.PhoneNumber;
                tk.UserEmailID = userMaster.UserEmailID;
                tk.IsDelete = userMaster.IsDelete;
                tk.MaDoan = userMaster.MaDoan;
                tk.UserID = userMaster.UserID;
                models.UserMasters.Add(tk);
                models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public string CapNhatTaiKhoan(UserMasterDTO userMaster)
        {
            string status = "ok";
                try
                {
                    var tk = models.UserMasters.Where(s => s.ID == userMaster.ID).FirstOrDefault();
                    if(tk != null)
                    {
                        tk.UserName = userMaster.UserName.Trim();
                        tk.UserPassword = userMaster.UserPassword;
                        tk.UserRoles = userMaster.UserRoles;
                        tk.FullName = userMaster.FullName;
                        tk.PhoneNumber = userMaster.PhoneNumber;
                        tk.UserEmailID = userMaster.UserEmailID;
                        tk.IsDelete = userMaster.IsDelete;
                        tk.MaDoan = userMaster.MaDoan;
                        tk.UserID = userMaster.UserID;
                        models.SaveChanges();
                    }               
                }
                catch (Exception)
                {
                    return status = "Lỗi không thể lưu tài khoản!";
                }
            return status;
        }
        public bool XoaTaiKhoan(int idUserMaster)
        {
            var userMaster = models.UserMasters.Where(e => e.ID == idUserMaster).FirstOrDefault();
            if (userMaster != null)
            {
                userMaster.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Phong
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
            lstphong = lstphong.OrderBy(l => l.LoaiPhong).ToList();
            return lstphong.ToList();
        }
        public PhongDTO LayPhong(int idPhong)
        {
            var phong = models.Phongs.Where(e => e.ID == idPhong).Select(e => new PhongDTO
            {
                ID = e.ID,
                MaPhong = e.MaPhong,
                SoPhong = e.SoPhong,
                LoaiPhong = e.LoaiPhong,
                Gia = e.Gia,
                TrangThai = e.TrangThai,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return phong;
        }
        public string ThemPhong(PhongDTO phong)
        {
            string status = "ok";
            Phong ph = new Phong();
            if (CheckPhong(phong.SoPhong))
            {
                ph.MaPhong = phong.MaPhong;
                ph.SoPhong = phong.SoPhong;
                ph.LoaiPhong = phong.LoaiPhong;
                ph.Gia = phong.Gia;
                ph.TrangThai = phong.TrangThai;
                ph.IsDelete = phong.IsDelete;
                models.Phongs.Add(ph);
                models.SaveChanges();
                return status;
            }
            else
            {
                return "Lỗi phòng đã tồn tại!";
            }

        }
        public bool CapNhatPhong(PhongDTO phong)
        {
            try
            {
                var ph = models.Phongs.Where(s => s.ID == phong.ID).FirstOrDefault();
                ph.MaPhong = phong.MaPhong;
                ph.SoPhong = phong.SoPhong;
                ph.LoaiPhong = phong.LoaiPhong;
                ph.Gia = phong.Gia;

                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaPhong(int idPhong)
        {
            var phong = models.Phongs.Where(e => e.ID == idPhong).FirstOrDefault();
            if (phong != null)
            {
                phong.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            return false;
        }
        public List<QuanLyLoaiPhongDTO> LayDanhSachLoaiPhong()
        {
            List<QuanLyLoaiPhongDTO> quanLyLoaiPhongDTOs = new List<QuanLyLoaiPhongDTO>();

            var lstPhong = models.Phongs.GroupBy(p => p.LoaiPhong).ToList();
            foreach (var phong in lstPhong)
            {
                QuanLyLoaiPhongDTO quanLyLoaiPhongDTO = new QuanLyLoaiPhongDTO();
                quanLyLoaiPhongDTO.LoaiPhong = int.Parse(phong.Key.ToString());
                foreach (var gia in phong)
                {
                    quanLyLoaiPhongDTO.Gia = gia.Gia;
                    break;
                }
                quanLyLoaiPhongDTOs.Add(quanLyLoaiPhongDTO);
            }
            return quanLyLoaiPhongDTOs;
        }
        public bool CapNhatLoaiPhong(List<QuanLyLoaiPhongDTO> quanLyLoaiPhongDTOs)
        {
            try
            {
                var lstPhong = models.Phongs.ToList();
                foreach (var phong in lstPhong)
                {
                    foreach (var loaiPhong in quanLyLoaiPhongDTOs)
                    {
                        if (phong.LoaiPhong == loaiPhong.LoaiPhong)
                            phong.Gia = loaiPhong.Gia;
                    }
                }
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        #endregion

        #region DichVu
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
        public DichVuDTO LayDichVu(int idDichVu)
        {
            var dichvu = models.DichVus.Where(e => e.ID == idDichVu).Select(e => new DichVuDTO
            {
                ID = e.ID,
                TenDichVu = e.TenDichVu,
                Gia = e.Gia,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return dichvu;
        }
        public bool ThemDichVu(DichVuDTO dichVu)
        {
            Models.Entities.DichVu dv = new Models.Entities.DichVu();
            if (CheckDichVu(dichVu.TenDichVu))
            {

                dv.TenDichVu = dichVu.TenDichVu;
                dv.Gia = dichVu.Gia;
                dv.IsDelete = dichVu.IsDelete;
                dv.MoTa = dichVu.MoTa;
                models.DichVus.Add(dv);
                models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }



        }
        public bool CapNhatDichVu(DichVuDTO dichVu)
        {
            try
            {
                var dv = models.DichVus.Where(s => s.ID == dichVu.ID).FirstOrDefault();
                dv.TenDichVu = dichVu.TenDichVu;
                dv.Gia = dichVu.Gia;
                dv.MoTa = dichVu.MoTa;
                models.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaDichVu(int idDichVu)
        {
            var dichvu = models.DichVus.Where(e => e.ID == idDichVu).FirstOrDefault();
            if (dichvu != null)
            {
                dichvu.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region TienIch
        public List<TienIchDTO> LayDanhSachTienIch()
        {
            var tienich = models.TienIches.Where(e => e.IsDelete == false).Select(e => new TienIchDTO
            {
                ID = e.ID,
                TenTienIch = e.TenTienIch,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            });
            return tienich.ToList();
        }
        public TienIchDTO LayTienIch(int idtienich)
        {
            var tienich = models.TienIches.Where(e => e.ID == idtienich).Select(e => new TienIchDTO
            {
                ID = e.ID,
                TenTienIch = e.TenTienIch,
                MoTa = e.MoTa,
                IsDelete = e.IsDelete
            }).FirstOrDefault();
            return tienich;
        }
        public bool ThemTienIch(TienIchDTO tienIch)
        {

            if (CheckTienIch(tienIch.TenTienIch))
            {
                Models.Entities.TienIch tienich = new Models.Entities.TienIch();
                tienich.TenTienIch = tienIch.TenTienIch;
                tienich.MoTa = tienIch.MoTa;
                tienich.IsDelete = tienIch.IsDelete;
                models.TienIches.Add(tienich);
                models.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CapNhatTienIch(TienIchDTO tienIch)
        {
            try
            {
                var tienich = models.TienIches.Where(s => s.ID == tienIch.ID).FirstOrDefault();
                tienich.TenTienIch = tienIch.TenTienIch;
                tienich.MoTa = tienIch.MoTa;

                models.SaveChanges();
                return true;

            }
            catch (Exception)

            {
                return false;
            }
        }
        public bool XoaTienIch(int idTienIch)
        {
            var tienich = models.TienIches.Where(e => e.ID == idTienIch).FirstOrDefault();
            if (tienich != null)
            {
                tienich.IsDelete = true;
                models.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Thong Ke
        public List<ThongKeTheoThangDTO> BaoCaoThongKeTheoThang(int thang, int nam)
        {
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong != -1).Select(kh => new KhachHangDTO
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
            var lstDV = models.DichVus.Where(d => d.IsDelete != true).Select(d => d.TenDichVu).ToList();
            List<ThongKeTheoThangDTO> lstBaoCaoThongKeDTO = new List<ThongKeTheoThangDTO>();

            lstBaoCaoThongKeDTO.Add(DoanhThuChoThuePhongTheoThang(thang, nam, lstPhong, lstKhachHang));
            foreach (var dv in lstDV)
            {
                lstBaoCaoThongKeDTO.Add(ThongKeDichVuTheoThang(thang, nam, dv));
            }
            return lstBaoCaoThongKeDTO;
        }
        public List<ThongKeTheoQuyDTO> BaoCaoThongKeTheoQuy(int quy, int nam)
        {
            var lstKhachHang = models.KhachHangs.Where(kh => kh.TrangThaiDatPhong != -1).Select(kh => new KhachHangDTO
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
            int thang1 = 1;
            int thang2 = 2;
            int thang3 = 3;
            switch (quy)
            {
                case 1: break;
                case 2:
                    thang1 = 4;
                    thang2 = 5;
                    thang3 = 6;
                    break;
                case 3:
                    thang1 = 7;
                    thang2 = 8;
                    thang3 = 9;
                    break;
                case 4:
                    thang1 = 10;
                    thang2 = 11;
                    thang3 = 12;
                    break;
            }
            List<ThongKeTheoQuyDTO> thongKeTheoQuyDTOs = new List<ThongKeTheoQuyDTO>();
            thongKeTheoQuyDTOs.Add(DoanhThuChoThuePhongTheoQuy(thang1, thang2, thang3, nam, lstPhong, lstKhachHang));
            var lstTenDv = models.DichVus.Where(d => d.IsDelete != true).Select(d => d.TenDichVu).ToList();
            foreach (var dv in lstTenDv)
            {
                thongKeTheoQuyDTOs.Add(ThongKeDichVuTheoQuy(thang1, thang2, thang3, nam, dv));
            }

            return thongKeTheoQuyDTOs;
        }
        public SoSanhThongKeDTO SoSanhThongKeTheoThang(int thang, int nam)
        {
            double doanhThuThuePhongHT = 0;
            double doanhThuDichVuHT = 0;
            double doanhThuThuePhongQK = 0;
            double doanhThuDichVuQK = 0;
            List<ThongKeTheoThangDTO> lstThongKeTheoThangHienTai;
            List<ThongKeTheoThangDTO> lstThongKeTheoThangTruoc;
            lstThongKeTheoThangHienTai = BaoCaoThongKeTheoThang(thang, nam);
            if (thang != 1)
                lstThongKeTheoThangTruoc = BaoCaoThongKeTheoThang(thang - 1, nam);
            else
                lstThongKeTheoThangTruoc = BaoCaoThongKeTheoThang(12, nam - 1);
            foreach (var thongKe in lstThongKeTheoThangHienTai)
            {
                if (thongKe.TenDichVu.Equals("Cho thuê phòng"))
                    doanhThuThuePhongHT += thongKe.DoanThu;
                else
                    doanhThuDichVuHT += thongKe.DoanThu;
            }
            foreach (var thongKe in lstThongKeTheoThangTruoc)
            {
                if (thongKe.TenDichVu.Equals("Cho thuê phòng"))
                    doanhThuThuePhongQK += thongKe.DoanThu;
                else
                    doanhThuDichVuQK += thongKe.DoanThu;
            }
            SoSanhThongKeDTO soSanhThongKeDTO = new SoSanhThongKeDTO();
            if (doanhThuDichVuQK == 0)
                doanhThuDichVuQK = doanhThuDichVuHT;
            if (doanhThuThuePhongQK == 0)
                doanhThuThuePhongQK = doanhThuThuePhongHT;
            if (doanhThuDichVuHT == 0 && doanhThuDichVuQK == 0)
                soSanhThongKeDTO.TienDichVu = 0;
            else
                soSanhThongKeDTO.TienDichVu = (doanhThuDichVuHT / doanhThuDichVuQK) * 100;
            if (doanhThuThuePhongHT == 0 && doanhThuThuePhongQK == 0)
                soSanhThongKeDTO.TienThuePhong = 0;
            else
                soSanhThongKeDTO.TienThuePhong = (doanhThuThuePhongHT / doanhThuThuePhongQK) * 100;

            return soSanhThongKeDTO;
        }
        public SoSanhThongKeDTO SoSanhThongKeTheoQuy(int quy, int nam)
        {
            double doanhThuThuePhongHT = 0;
            double doanhThuDichVuHT = 0;
            double doanhThuThuePhongQK = 0;
            double doanhThuDichVuQK = 0;
            List<ThongKeTheoQuyDTO> lstThongKeTheoQuyHienTai;
            List<ThongKeTheoQuyDTO> lstThongKeTheoQuyTruoc;
            lstThongKeTheoQuyHienTai = BaoCaoThongKeTheoQuy(quy, nam);
            if (quy != 1)
                lstThongKeTheoQuyTruoc = BaoCaoThongKeTheoQuy(quy - 1, nam);
            else
                lstThongKeTheoQuyTruoc = BaoCaoThongKeTheoQuy(4, nam - 1);
            foreach (var thongKe in lstThongKeTheoQuyHienTai)
            {
                if (thongKe.TenDichVu.Equals("Cho thuê phòng"))
                    doanhThuThuePhongHT += thongKe.TrungBinh;
                else
                    doanhThuDichVuHT += thongKe.TrungBinh;
            }
            foreach (var thongKe in lstThongKeTheoQuyTruoc)
            {
                if (thongKe.TenDichVu.Equals("Cho thuê phòng"))
                    doanhThuThuePhongQK += thongKe.TrungBinh;
                else
                    doanhThuDichVuQK += thongKe.TrungBinh;
            }
            SoSanhThongKeDTO soSanhThongKeDTO = new SoSanhThongKeDTO();
            if (doanhThuDichVuQK == 0)
                doanhThuDichVuQK = doanhThuDichVuHT;
            if (doanhThuThuePhongQK == 0)
                doanhThuThuePhongQK = doanhThuThuePhongHT;
            if (doanhThuDichVuHT == 0 && doanhThuDichVuQK == 0)
                soSanhThongKeDTO.TienDichVu = 0;
            else
                soSanhThongKeDTO.TienDichVu = (doanhThuDichVuHT / doanhThuDichVuQK) * 100;
            if (doanhThuThuePhongHT == 0 && doanhThuThuePhongQK == 0)
                soSanhThongKeDTO.TienThuePhong = 0;
            else
                soSanhThongKeDTO.TienThuePhong = (doanhThuThuePhongHT / doanhThuThuePhongQK) * 100;
            return soSanhThongKeDTO;
        }
        #endregion

        #region Private Methods
        private bool CheckUserMaster(string  userName)
        {
            bool b = true;
            var lstUserMaster = models.UserMasters.ToList();
            foreach (var item in lstUserMaster)
            {
                if (userName.Equals(item.UserName))
                    b = false;
            }
            return b;
        }
        private bool CheckPhong(String soPhong)
        {
            bool b = true;
            List<PhongDTO> lstPhong = models.Phongs.Select(s => new PhongDTO
            {
                MaPhong = s.MaPhong,
                SoPhong = s.SoPhong,
                LoaiPhong = s.LoaiPhong,
                Gia = s.Gia,
                TrangThai = s.TrangThai,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstPhong)
            {
                if (soPhong.Equals(item.SoPhong))
                {
                    if (item.IsDelete)
                        item.IsDelete = false;
                    else
                        b = false;
                }


            }
            return b;
        }
        private bool CheckDichVu(String tenDichVu)
        {
            bool b = true;
            List<DichVuDTO> lstDichVu = models.DichVus.Select(s => new DichVuDTO
            {
                TenDichVu = s.TenDichVu,
                Gia = s.Gia,
                MoTa = s.MoTa,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstDichVu)
            {
                if (tenDichVu.Equals(item.TenDichVu))
                    b = false;
            }
            return b;
        }
        private bool CheckTienIch(String tenTienIch)
        {
            bool b = true;
            List<TienIchDTO> lstTienIch = models.TienIches.Select(s => new TienIchDTO
            {
                TenTienIch = s.TenTienIch,
                MoTa = s.MoTa,
                IsDelete = s.IsDelete
            }).ToList();
            foreach (var item in lstTienIch)
            {
                if (tenTienIch.Equals(item.TenTienIch))
                    b = false;
            }
            return b;
        }
        private int TinhNgayCuoiThang(int thang, int nam)
        {
            int soNgay = 0;
            bool testNamNhuan = false;
            //Kiem tra nam nhuan
            if ((nam % 400) == 0)
                testNamNhuan = true;
            else if ((nam % 100) == 0)
                testNamNhuan = false;
            else if ((nam % 4) == 0)
                testNamNhuan = true;
            else
                testNamNhuan = false;
            //Kiem tra thang
            switch (thang)
            {
                case 1: soNgay = 31; break;
                case 2: soNgay = testNamNhuan ? 29 : 28; break;
                case 3: soNgay = 31; break;
                case 4: soNgay = 30; break;
                case 5: soNgay = 31; break;
                case 6: soNgay = 30; break;
                case 7: soNgay = 31; break;
                case 8: soNgay = 31; break;
                case 9: soNgay = 30; break;
                case 10: soNgay = 31; break;
                case 11: soNgay = 30; break;
                case 12: soNgay = 31; break;
            }
            return soNgay;
        }
        private ThongKeTheoThangDTO DoanhThuChoThuePhongTheoThang(int thang, int nam, List<PhongDTO> phongDTOs, List<KhachHangDTO> khachHangDTOs)
        {
            int cuoiThang = TinhNgayCuoiThang(thang, nam);
            double doanhThu = 0;
            foreach (var phong in phongDTOs)
            {
                var lstKhachHangTheoPhong = khachHangDTOs.Where(kh => kh.IDPhong == phong.ID && kh.ThoiGianTra.Year == nam && kh.ThoiGianTra.Month == thang).GroupBy(kh => kh.ThoiGianNhan).ToList();

                foreach (var key in lstKhachHangTheoPhong)
                {
                    var khachHang = key.FirstOrDefault();
                    if (KiemTraThoiGianDatPhong(khachHang.ThoiGianTra, cuoiThang))
                    {
                        TimeSpan timeSpan = khachHang.ThoiGianTra - khachHang.ThoiGianNhan;
                        int soNgay = timeSpan.Days;
                        doanhThu += phong.Gia * soNgay;
                    }
                }
            }
            ThongKeTheoThangDTO baoCaoThongKe = new ThongKeTheoThangDTO();
            baoCaoThongKe.TenDichVu = "Cho thuê phòng";
            baoCaoThongKe.DoanThu = doanhThu;
            return baoCaoThongKe;
        }
        private bool KiemTraThoiGianDatPhong(DateTime ngayTra, int cuoiThang)
        {
            int ngayTraPhong = ngayTra.Day;
            if (ngayTraPhong >= 1 && ngayTraPhong <= cuoiThang)
                return true;
            else
                return false;
        }
        private ThongKeTheoQuyDTO DoanhThuChoThuePhongTheoQuy(int thang1, int thang2, int thang3, int nam, List<PhongDTO> phongDTOs, List<KhachHangDTO> khachHangDTOs)
        {
            var doanhThuChoThuePhongThang1 = DoanhThuChoThuePhongTheoThang(thang1, nam, phongDTOs, khachHangDTOs);
            var doanhThuChoThuePhongThang2 = DoanhThuChoThuePhongTheoThang(thang2, nam, phongDTOs, khachHangDTOs);
            var doanhThuChoThuePhongThang3 = DoanhThuChoThuePhongTheoThang(thang3, nam, phongDTOs, khachHangDTOs);

            ThongKeTheoQuyDTO thongKeTheoQuyDTO = new ThongKeTheoQuyDTO();
            thongKeTheoQuyDTO.TenDichVu = doanhThuChoThuePhongThang1.TenDichVu;
            thongKeTheoQuyDTO.DoanhThu1 = doanhThuChoThuePhongThang1.DoanThu;
            thongKeTheoQuyDTO.DoanhThu2 = doanhThuChoThuePhongThang2.DoanThu;
            thongKeTheoQuyDTO.DoanhThu3 = doanhThuChoThuePhongThang3.DoanThu;
            thongKeTheoQuyDTO.TrungBinh = (doanhThuChoThuePhongThang1.DoanThu + doanhThuChoThuePhongThang2.DoanThu + doanhThuChoThuePhongThang3.DoanThu) / 3;
            return thongKeTheoQuyDTO;
        }
        private bool TaoDanhSachPhongTheoLoaiPhong(int loaiPhong, int lau, int soLuong, int gia)
        {
            try
            {
                for (int i = 0; i < soLuong; i++)
                {
                    Phong phong = new Phong();
                    string maLau = lau < 10 ? "0" + lau : lau.ToString();
                    string maPhong = soPhong < 10 ? "0" + lau : lau.ToString();
                    phong.MaPhong = loaiPhong.ToString() + maLau + maPhong;
                    phong.SoPhong = maPhong;
                    phong.LoaiPhong = loaiPhong;
                    phong.IsDelete = false;
                    phong.TrangThai = -1;
                    phong.Gia = gia;
                    models.Phongs.Add(phong);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        private ThongKeTheoThangDTO ThongKeDichVuTheoThang(int thang, int nam, string tenDV)
        {
            ThongKeTheoThangDTO thongKeTheoThangDTO = new ThongKeTheoThangDTO();
            double doanhThu = 0;
            var lstDV = models.LichSuDichVus.Where(l => l.TenDichVu.Equals(tenDV) && l.NgayGoiDichVu.Month == thang && l.NgayGoiDichVu.Year == nam).ToList();
            var gia = models.DichVus.Where(d => d.TenDichVu.Equals(tenDV)).Select(d => d.Gia).FirstOrDefault();
            foreach (var dv in lstDV)
            {
                doanhThu += gia;
            }
            thongKeTheoThangDTO.DoanThu = doanhThu;
            thongKeTheoThangDTO.TenDichVu = tenDV;
            return thongKeTheoThangDTO;
        }
        private ThongKeTheoQuyDTO ThongKeDichVuTheoQuy(int thang1, int thang2, int thang3, int nam, string tenDV)
        {
            ThongKeTheoQuyDTO thongKeTheoQuyDTO = new ThongKeTheoQuyDTO();
            thongKeTheoQuyDTO.TenDichVu = tenDV;
            thongKeTheoQuyDTO.DoanhThu1 = ThongKeDichVuTheoThang(thang1, nam, tenDV).DoanThu;
            thongKeTheoQuyDTO.DoanhThu2 = ThongKeDichVuTheoThang(thang2, nam, tenDV).DoanThu;
            thongKeTheoQuyDTO.DoanhThu3 = ThongKeDichVuTheoThang(thang3, nam, tenDV).DoanThu;
            thongKeTheoQuyDTO.TrungBinh = (thongKeTheoQuyDTO.DoanhThu1 + thongKeTheoQuyDTO.DoanhThu2 + thongKeTheoQuyDTO.DoanhThu3) / 3;
            return thongKeTheoQuyDTO;
        }
        #endregion

    }
}