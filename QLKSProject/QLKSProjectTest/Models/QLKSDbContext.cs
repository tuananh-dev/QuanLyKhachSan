
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QLKSProjectTest.Models.Entities;


namespace QLKSProjectTest.Models
{
    public class QLKSDbContext : DbContext
    {
        public QLKSDbContext() : base("Team2Connection1")
        {

        }

        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<Doan> Doans { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LichSuDichVu> LichSuDichVus { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<TienIch> TienIches { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
    }
}