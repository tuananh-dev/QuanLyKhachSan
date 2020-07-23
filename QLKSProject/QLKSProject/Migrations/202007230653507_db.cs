namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(nullable: false, maxLength: 50),
                        MoTa = c.String(nullable: false, maxLength: 2000),
                        Gia = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LichSuDichVus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPhong = c.Int(nullable: false),
                        IDDichVu = c.Int(nullable: false),
                        NgayGoiDichVu = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
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
                "dbo.KhachHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HoVaTen = c.String(nullable: false, maxLength: 100),
                        SoDienThoai = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 200),
                        DiaChi = c.String(nullable: false, maxLength: 200),
                        Nhom = c.Int(nullable: false),
                        NguoiDaiDienCuaTreEm = c.String(maxLength: 100),
                        ThoiGianNhan = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ThoiGianTra = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MaDoan = c.String(nullable: false, maxLength: 50),
                        GioiTinh = c.Boolean(nullable: false),
                        LoaiKhachHang = c.Boolean(nullable: false),
                        TruongDoan = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        TrangThaiDatPhong = c.Boolean(nullable: false),
                        IDPhong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doans", t => t.MaDoan, cascadeDelete: true)
                .Index(t => t.MaDoan);
            
            CreateTable(
                "dbo.Doans",
                c => new
                    {
                        MaDoan = c.String(nullable: false, maxLength: 50),
                        ID = c.Int(nullable: false, identity: true),
                        TenDoan = c.String(nullable: false, maxLength: 200),
                        NgayGui = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TenTruongDoan = c.String(nullable: false, maxLength: 100),
                        ThoiGianNhan = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ThoiGianTra = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDelete = c.Boolean(nullable: false),
                        TrangThaiDatPhong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDoan);
            
            CreateTable(
                "dbo.Phongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaPhong = c.String(nullable: false, maxLength: 5),
                        SoPhong = c.String(nullable: false, maxLength: 3),
                        LoaiPhong = c.Int(nullable: false),
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
                        MoTa = c.String(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LichSuDichVus", "IDPhong", "dbo.Phongs");
            DropForeignKey("dbo.LichSuDichVus", "IDKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.KhachHangs", "MaDoan", "dbo.Doans");
            DropForeignKey("dbo.LichSuDichVus", "IDDichVu", "dbo.DichVus");
            DropIndex("dbo.KhachHangs", new[] { "MaDoan" });
            DropIndex("dbo.LichSuDichVus", new[] { "IDKhachHang" });
            DropIndex("dbo.LichSuDichVus", new[] { "IDDichVu" });
            DropIndex("dbo.LichSuDichVus", new[] { "IDPhong" });
            DropTable("dbo.TienIches");
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.Phongs");
            DropTable("dbo.Doans");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.LichSuDichVus");
            DropTable("dbo.DichVus");
        }
    }
}
