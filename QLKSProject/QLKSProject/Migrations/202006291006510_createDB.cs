namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
<<<<<<< HEAD:QLKSProject/QLKSProject/Migrations/202006290754251_g.cs
    public partial class g : DbMigration
=======
    public partial class createDB : DbMigration
>>>>>>> b4de312ef247bbb90f834c12e3bdad425a1fda8b:QLKSProject/QLKSProject/Migrations/202006291006510_createDB.cs
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatPhongThanhCongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKhachHang = c.Int(nullable: false),
                        IDPhong = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        NgayTraPhongThucTe = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KhachHangs", t => t.IDKhachHang, cascadeDelete: true)
                .ForeignKey("dbo.Phongs", t => t.IDPhong, cascadeDelete: true)
                .Index(t => t.IDKhachHang)
                .Index(t => t.IDPhong);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HoVaTen = c.String(nullable: false, maxLength: 50),
                        SoDienThoai = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(nullable: false, maxLength: 200),
                        Nhom = c.String(nullable: false, maxLength: 50),
                        NguoiDaiDienCuaTreEm = c.String(nullable: false, maxLength: 100),
                        ThoiGianNhan = c.DateTime(nullable: false),
                        ThoiGianTra = c.DateTime(nullable: false),
                        MaDoan = c.String(nullable: false, maxLength: 50),
                        GioiTinh = c.Boolean(nullable: false),
                        LoaiKhachHang = c.Boolean(nullable: false),
                        TruongDoan = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        TenDoan = c.String(),
                        NgayGui = c.DateTime(),
                        TenTruongDoan = c.String(),
                        ThoiGianNhan = c.DateTime(),
                        ThoiGianTra = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doans", t => t.MaDoan, cascadeDelete: true)
                .Index(t => t.MaDoan);
            
            CreateTable(
                "dbo.Doans",
                c => new
                    {
                        MaDoan = c.String(nullable: false, maxLength: 50),
                        TenDoan = c.String(nullable: false, maxLength: 50),
                        NgayGui = c.DateTime(nullable: false),
                        TenTruongDoan = c.String(nullable: false, maxLength: 50),
                        ThoiGianNhan = c.DateTime(nullable: false),
                        ThoiGianTra = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaDoan);
            
            CreateTable(
                "dbo.DatPhongThatBais",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDoan = c.String(nullable: false, maxLength: 200),
                        MaDoan = c.String(nullable: false, maxLength: 50),
                        GhiChu = c.String(maxLength: 2000),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doans", t => t.MaDoan, cascadeDelete: true)
                .Index(t => t.MaDoan);
            
            CreateTable(
                "dbo.LichSuDichVus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPhong = c.Int(nullable: false),
                        IDDichVu = c.Int(nullable: false),
                        NgayGoiDichVu = c.DateTime(nullable: false),
                        GhiChu = c.String(),
                        IDKhachHang = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DichVus", t => t.IDDichVu, cascadeDelete: true)
                .ForeignKey("dbo.KhachHangs", t => t.IDKhachHang, cascadeDelete: true)
                .ForeignKey("dbo.Phongs", t => t.IDPhong, cascadeDelete: true)
                .Index(t => t.IDPhong)
                .Index(t => t.IDDichVu)
                .Index(t => t.IDKhachHang);
            
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(nullable: false, maxLength: 50),
                        Gia = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Phongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaPhong = c.String(nullable: false, maxLength: 5),
                        SoPhong = c.String(nullable: false, maxLength: 3),
                        LoaiPhong = c.String(nullable: false, maxLength: 10),
                        Gia = c.Int(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTaiKhoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 8),
                        HoVaTen = c.String(nullable: false, maxLength: 50),
                        SoDienThoai = c.String(nullable: false, maxLength: 50),
                        Mail = c.String(nullable: false, maxLength: 50),
                        LoaiTaiKhoan = c.String(nullable: false, maxLength: 6),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TienIches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTienIch = c.String(nullable: false, maxLength: 50),
                        HinhAnh = c.String(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LichSuDichVus", "IDPhong", "dbo.Phongs");
            DropForeignKey("dbo.DatPhongThanhCongs", "IDPhong", "dbo.Phongs");
            DropForeignKey("dbo.LichSuDichVus", "IDKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.LichSuDichVus", "IDDichVu", "dbo.DichVus");
            DropForeignKey("dbo.KhachHangs", "MaDoan", "dbo.Doans");
            DropForeignKey("dbo.DatPhongThatBais", "MaDoan", "dbo.Doans");
            DropForeignKey("dbo.DatPhongThanhCongs", "IDKhachHang", "dbo.KhachHangs");
            DropIndex("dbo.LichSuDichVus", new[] { "IDKhachHang" });
            DropIndex("dbo.LichSuDichVus", new[] { "IDDichVu" });
            DropIndex("dbo.LichSuDichVus", new[] { "IDPhong" });
            DropIndex("dbo.DatPhongThatBais", new[] { "MaDoan" });
            DropIndex("dbo.KhachHangs", new[] { "MaDoan" });
            DropIndex("dbo.DatPhongThanhCongs", new[] { "IDPhong" });
            DropIndex("dbo.DatPhongThanhCongs", new[] { "IDKhachHang" });
            DropTable("dbo.TienIches");
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.Phongs");
            DropTable("dbo.DichVus");
            DropTable("dbo.LichSuDichVus");
            DropTable("dbo.DatPhongThatBais");
            DropTable("dbo.Doans");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DatPhongThanhCongs");
        }
    }
}
