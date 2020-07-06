﻿using System;


namespace QLKSProject.Models.DTO
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Nhom { get; set; }
        public string NguoiDaiDienCuaTreEm { get; set; }
        public DateTime ThoiGianNhan { get; set; }
        public DateTime ThoiGianTra { get; set; }
        public string MaDoan { get; set; }
        public bool GioiTinh { get; set; }
        public bool LoaiKhachHang { get; set; }
        public bool TruongDoan { get; set; }
        public bool IsDelete { get; set; }
    }
}