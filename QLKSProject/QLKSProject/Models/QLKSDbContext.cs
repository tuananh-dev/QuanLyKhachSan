
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QLKSProject.Models.Entities;


namespace QLKSProject.Models
{
    public class QLKSDbContext : DbContext
    {
        public QLKSDbContext() : base("Team2Connection1")
        {

        }

        public DbSet<DatPhongThanhCong> DatPhongThanhCongs { get; set; }
        public DbSet<DatPhongThatBai> DatPhongThatBais { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<Doan> Doans { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LichSuDichVu> LichSuDichVus { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<TienIch> TienIches { get; set; }


    }
}