using System;
using System.Collections.Generic;
using System.Linq;
using QLKSProject.Models.DTO;
namespace QLKSProject.Business.Home
{

    public class HomeBusiness : BaseBusiness
    {
        private string error = "ok";
        #region Public methods
        public string LayFileDanhSachKhachHang(string tenDoan, string tenTruongDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string fileDSKhachHang)
        {
            string maDoan = TaoMaDoan().ToString();

            try
            {
                TaoDoiTuongDoan(tenDoan, tenTruongDoan, thoiGianNhan, thoiGianTra, maDoan);
                List<KhachHangDTO> lstKhachHang = TaoDoiTuongKhachHang(fileDSKhachHang, maDoan, thoiGianNhan, thoiGianTra, tenTruongDoan);

                KiemTraNguoiDaiDien(lstKhachHang);
                KiemTraTruongDoan(lstKhachHang);
                KiemTraSoLuongThanhVienNhom(lstKhachHang);

                if (error.Equals("ok"))
                {
                    LuuDanhSachKhachHang(lstKhachHang);
                    models.SaveChanges();
                }
            }
            catch (Exception)
            {
                if (error.Equals("ok"))
                    error = "";
                error += "\r\n" + "Lưu file khách hàng không thành công!";
            }
            return error;
        }
        public bool CheckTaiKhoan(string maDoan)
        {
            var taiKhoan = models.UserMasters.Where(u => u.MaDoan == maDoan).FirstOrDefault();
            return taiKhoan.IsDelete;
        }
        #endregion

        #region Private methods
        private ulong TaoMaDoan()
        {
            DateTime now = DateTime.Now;
            DateTime time1970 = new DateTime(1970, 1, 1);
            TimeSpan layMa = now - time1970;
            return (ulong)layMa.TotalMilliseconds;
        }
        private void TaoDoiTuongDoan(string tenDoan, string tenTruongDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string maDoan)
        {
            DateTime today = DateTime.Now;
            Models.Entities.Doan doan = new Models.Entities.Doan();
            doan.MaDoan = maDoan;
            doan.TenDoan = tenDoan;
            doan.NgayGui = today;
            doan.TenTruongDoan = tenTruongDoan;
            doan.ThoiGianNhan = thoiGianNhan;
            doan.ThoiGianTra = thoiGianTra;
            doan.IsDelete = false;
            doan.TrangThaiDatPhong = 0;
            models.Doans.Add(doan);
        }
        private List<KhachHangDTO> TaoDoiTuongKhachHang(string fileKhachHang, string maDoan, DateTime thoiGianNhan, DateTime thoiGianTra, string tenTruongDoan)
        {
            List<KhachHangDTO> lstKhachHangDTO = new List<KhachHangDTO>();
            string strKhachHang = fileKhachHang.Replace("}", "{");
            strKhachHang = strKhachHang.Replace(":", "");
            strKhachHang = strKhachHang.Replace(",", "");
            string[] lstKhachHang = strKhachHang.Split('{');
            foreach (var item in lstKhachHang)
            {
                string[] lstThuocTinh = item.Split('"');
                if (lstThuocTinh.Length >= 8)
                {
                    KhachHangDTO khachHang = new KhachHangDTO();
                    khachHang.HoVaTen = lstThuocTinh[7].Trim();
                    khachHang.SoDienThoai = lstThuocTinh[11];
                    khachHang.Email = lstThuocTinh[15];
                    khachHang.DiaChi = lstThuocTinh[19];
                    khachHang.Nhom = int.Parse(lstThuocTinh[23]);
                    khachHang.NguoiDaiDienCuaTreEm = lstThuocTinh[31];
                    khachHang.ThoiGianNhan = thoiGianNhan;
                    khachHang.ThoiGianTra = thoiGianTra;
                    khachHang.MaDoan = maDoan;
                    khachHang.GioiTinh = RemoveUnicode(lstThuocTinh[35].ToLower().Replace(" ", "")).Equals("nu") ? false : true;
                    khachHang.LoaiKhachHang = lstThuocTinh[27].Trim().Equals("nl") ? false : true;
                    khachHang.TruongDoan = khachHang.HoVaTen.Trim().Equals(tenTruongDoan.Trim()) ? true : false;
                    khachHang.IsDelete = false;
                    khachHang.TrangThaiDatPhong = -1;
                    khachHang.IDPhong = -1;
                    khachHang.TrangThaiXacNhan = false;
                    lstKhachHangDTO.Add(khachHang);
                }
            }
            return lstKhachHangDTO;
        }
        private void KiemTraNguoiDaiDien(List<KhachHangDTO> khachHangDTOs)
        {
            var lstKhachHang = khachHangDTOs.Where(kh => kh.LoaiKhachHang != false).Select(s => s.NguoiDaiDienCuaTreEm).ToList();
            //Kiem tra khong co nguoi dai dien
            foreach (var kh in lstKhachHang)
            {
                if (kh.Equals("0"))
                {
                    if (error.Equals("ok"))
                        error = "";
                    error += "\r\n" + "Lỗi không có người đại diện của trẻ em!";
                    break;
                }
            }
            if (error.Equals("ok"))
            {
                foreach (var nguoiDaiDien in lstKhachHang)
                {
                    var checkNull = khachHangDTOs.Where(kh => kh.HoVaTen.Equals(nguoiDaiDien.Trim())).FirstOrDefault();
                    if (checkNull == null)
                    {
                        if (error.Equals("ok"))
                            error = "";
                        error += "\r\n" + "Lỗi không có người đại diện của trẻ em!";
                        break;
                    }
                    if (error.Equals("ok"))
                    {

                        //Kiem tra nguoi dai dien tre em la tre em
                        var checkNguoiDaiDienLaTreEm = khachHangDTOs.Where(kh => kh.HoVaTen.Equals(nguoiDaiDien) && kh.LoaiKhachHang != false).Select(kh => kh.HoVaTen).FirstOrDefault();
                        if (checkNguoiDaiDienLaTreEm != null)
                        {
                            if (error.Equals("ok"))
                                error = "";
                            error += "\r\n" + "Lỗi người đại diện của trẻ em là trẻ em! (" + checkNguoiDaiDienLaTreEm + ")";
                        }
                    }
                }
            }

        }
        private void KiemTraSoLuongThanhVienNhom(List<KhachHangDTO> khachHangDTOs)
        {
            var lstNhom = khachHangDTOs.GroupBy(s => s.Nhom).Select(g => g.Key).ToList();
            foreach (var nhom in lstNhom)
            {
                var lstKhachHangNhom = khachHangDTOs.Where(kh => kh.Nhom == nhom).ToList();
                if (TinhSoThanhVienNhom(lstKhachHangNhom) > 4)
                {
                    if (error.Equals("ok"))
                        error = "";
                    error += "\r\n" + "Số thành viên nhóm <" + nhom + "> lớn hơn 4!";
                    break;
                }
            }
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
        private void KiemTraTruongDoan(List<KhachHangDTO> khachHangDTOs)
        {
            var truongDoan = khachHangDTOs.Where(kh => kh.TruongDoan != false).FirstOrDefault();
            if (truongDoan == null)
            {
                if (error.Equals("ok"))
                    error = "";
                error += "\r\n" + "Lỗi <trưởng đoàn> không có trong danh sách khách hàng!";
            }
            if (truongDoan.LoaiKhachHang != false)
            {
                if (error.Equals("ok"))
                    error = "";
                error += "\r\n" + "Lỗi <trưởng đoàn> là trẻ em!";
            }

        }
        private void LuuDanhSachKhachHang(List<KhachHangDTO> khachHangDTOs)
        {
            foreach (var kh in khachHangDTOs)
            {
                Models.Entities.KhachHang khachHang = new Models.Entities.KhachHang();
                khachHang.HoVaTen = kh.HoVaTen;
                khachHang.SoDienThoai = kh.SoDienThoai;
                khachHang.Email = kh.Email;
                khachHang.DiaChi = kh.DiaChi;
                khachHang.Nhom = kh.Nhom;
                khachHang.NguoiDaiDienCuaTreEm = kh.NguoiDaiDienCuaTreEm;
                khachHang.ThoiGianNhan = kh.ThoiGianNhan;
                khachHang.ThoiGianTra = kh.ThoiGianTra;
                khachHang.MaDoan = kh.MaDoan;
                khachHang.GioiTinh = kh.GioiTinh;
                khachHang.LoaiKhachHang = kh.LoaiKhachHang;
                khachHang.TruongDoan = kh.TruongDoan;
                khachHang.IsDelete = kh.IsDelete;
                khachHang.TrangThaiDatPhong = kh.TrangThaiDatPhong;
                khachHang.IDPhong = kh.IDPhong;
                khachHang.GhiChu = kh.GhiChu;
                khachHang.TrangThaiXacNhan = kh.TrangThaiXacNhan;
                models.KhachHangs.Add(khachHang);
            }
        }
        #endregion

    }

}


