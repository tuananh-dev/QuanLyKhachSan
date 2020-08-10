using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models.DTO;

namespace QLKSProject.Business.KhachHangBusiness
{
    public class KhachHangBusiness : BaseBusiness
    {
        public List<KhachHangDTO> LayDanhSachKhachHangTheoMaDoan(string maDoan)
        {
            var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan && kh.IsDelete != true).Select(kh => new KhachHangDTO {
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
                TrangThaiXacNhan = kh.TrangThaiXacNhan,
                Sophong = models.Phongs.Where(p => p.ID == kh.IDPhong).Select(p => p.SoPhong).FirstOrDefault()
            }).ToList();
            //Xap xep khach hang theo nhom
            lstKhachHang = lstKhachHang.OrderBy(kh => kh.IDPhong).ToList();
            return lstKhachHang;
        }
        public bool XacNhanDatPhong(string maDoan)
        {
            bool b = false;
            var doan = models.Doans.Where(d => d.MaDoan == maDoan).FirstOrDefault();
            if(doan != null)
            {
                doan.TrangThaiXacNhan = true;
                b = true;
                var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).ToList();
                if (lstKhachHang.Count != 0)
                {
                    foreach (var khachHang in lstKhachHang)
                    {
                        khachHang.TrangThaiXacNhan = true;
                    }
                    b = true;
                    models.SaveChanges();
                    var khachHangDTO = lstKhachHang.Where(kh => kh.TruongDoan == true).FirstOrDefault();
                    string account = khachHangDTO.Email;
                    string subject = "Cám ơn quý khách đã xác nhận đặt phòng tại khách sạn Color Hotel";
                    string body = "Dear " + khachHangDTO.HoVaTen + ",<BR><BR>" + "Quý khách đã xác nhận đặt phòng thành công. Cám ơn quý khách đã sử dụng dịch vụ của chúng tôi!" + "<BR><BR>Trân trọng,<BR>" + "Hotel Color";
                    string trangThaiGuiMail = GuiMailTuDong(account, subject, body);
                }
                else
                    b = false;
                
            }
            else
                b = false;         
            return b;
        }
        public string HuyDatPhong(string maDoan)
        {
            string error = "ok";
            try
            {
                var doan = models.Doans.Where(d => d.MaDoan == maDoan).FirstOrDefault();
                var taiKhoan = models.UserMasters.Where(tk => tk.MaDoan == maDoan).FirstOrDefault();
                taiKhoan.IsDelete = true;
                if(doan.TrangThaiXacNhan != true)
                {
                    doan.IsDelete = true;
                    var lstKhachHang = models.KhachHangs.Where(kh => kh.MaDoan == maDoan).ToList();
                    foreach (var kh in lstKhachHang)
                    {
                        kh.IsDelete = true;
                        kh.IDPhong = -2;
                        kh.TrangThaiDatPhong = -2;
                        kh.GhiChu = "Khách hàng đã hủy đặt phòng";
                    }
                    models.SaveChanges();
                    #region Gui Mail cho khach hang
                    var khachHangDTO = lstKhachHang.Where(kh => kh.TruongDoan == true).FirstOrDefault();
                    string account = khachHangDTO.Email;
                    string subject = "Quý khách đã hủy đặt phòng tại khách sạn Color Hotel";
                    string body = "Dear " + khachHangDTO.HoVaTen + ",<BR><BR>" + "Quý khách đã hủy đặt phòng thành công.<BR>Cám ơn quý khách đã sử dụng dịch vụ của chúng tôi!" + "<BR><BR>Trân trọng,<BR>" + "Hotel Color";
                    string trangThaiGuiMail = GuiMailTuDong(account, subject, body);
                    #endregion
                }
                else
                    error = "Hủy danh sách khách hàng lỗi!";
            }
            catch (Exception)
            {
                error = "Hủy danh sách khách hàng lỗi!";
            }
            return error;
        }
        #region
        #endregion
    }
}