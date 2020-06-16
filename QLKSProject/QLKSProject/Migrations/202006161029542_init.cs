namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatPhongThanhCongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPhong = c.Int(nullable: false),
                        ThoiGianNhan = c.DateTime(nullable: false),
                        ThoiGianTra = c.DateTime(nullable: false),
                        IDKhachHang = c.Int(nullable: false),
                        SoDienThoai = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(nullable: false, maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HoVaTen = c.String(nullable: false, maxLength: 50),
                        SoDienThoai = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(nullable: false, maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        TruongDoan = c.String(nullable: false, maxLength: 50),
                        DatPhongThanhCong_ID = c.Int(),
                        DatPhongThatBai_ID = c.Int(),
                        PhongSuDungDichVu_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DatPhongThanhCongs", t => t.DatPhongThanhCong_ID)
                .ForeignKey("dbo.DatPhongThatBais", t => t.DatPhongThatBai_ID)
                .ForeignKey("dbo.PhongSuDungDichVus", t => t.PhongSuDungDichVu_ID)
                .Index(t => t.DatPhongThanhCong_ID)
                .Index(t => t.DatPhongThatBai_ID)
                .Index(t => t.PhongSuDungDichVu_ID);
            
            CreateTable(
                "dbo.DatPhongThatBais",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKhachHang = c.Int(nullable: false),
                        GhiChu = c.String(maxLength: 300),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PhongSuDungDichVus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDPhong = c.Int(nullable: false),
                        IDDichVu = c.Int(nullable: false),
                        NgayGoiDichVu = c.DateTime(nullable: false),
                        IDKhachHang = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(nullable: false, maxLength: 50),
                        Gia = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        PhongSuDungDichVu_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PhongSuDungDichVus", t => t.PhongSuDungDichVu_ID)
                .Index(t => t.PhongSuDungDichVu_ID);
            
            CreateTable(
                "dbo.Phongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoPhong = c.String(nullable: false, maxLength: 5),
                        LoaiPhong = c.String(nullable: false, maxLength: 10),
                        Gia = c.Int(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        DatPhongThanhCong_ID = c.Int(),
                        PhongSuDungDichVu_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DatPhongThanhCongs", t => t.DatPhongThanhCong_ID)
                .ForeignKey("dbo.PhongSuDungDichVus", t => t.PhongSuDungDichVu_ID)
                .Index(t => t.DatPhongThanhCong_ID)
                .Index(t => t.PhongSuDungDichVu_ID);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenTaiKhoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 8),
                        HoVaTen = c.String(nullable: false, maxLength: 50),
                        SoDienThoai = c.Int(nullable: false),
                        Mail = c.String(nullable: false, maxLength: 50),
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
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phongs", "PhongSuDungDichVu_ID", "dbo.PhongSuDungDichVus");
            DropForeignKey("dbo.Phongs", "DatPhongThanhCong_ID", "dbo.DatPhongThanhCongs");
            DropForeignKey("dbo.KhachHangs", "PhongSuDungDichVu_ID", "dbo.PhongSuDungDichVus");
            DropForeignKey("dbo.DichVus", "PhongSuDungDichVu_ID", "dbo.PhongSuDungDichVus");
            DropForeignKey("dbo.KhachHangs", "DatPhongThatBai_ID", "dbo.DatPhongThatBais");
            DropForeignKey("dbo.KhachHangs", "DatPhongThanhCong_ID", "dbo.DatPhongThanhCongs");
            DropIndex("dbo.Phongs", new[] { "PhongSuDungDichVu_ID" });
            DropIndex("dbo.Phongs", new[] { "DatPhongThanhCong_ID" });
            DropIndex("dbo.DichVus", new[] { "PhongSuDungDichVu_ID" });
            DropIndex("dbo.KhachHangs", new[] { "PhongSuDungDichVu_ID" });
            DropIndex("dbo.KhachHangs", new[] { "DatPhongThatBai_ID" });
            DropIndex("dbo.KhachHangs", new[] { "DatPhongThanhCong_ID" });
            DropTable("dbo.TienIches");
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.Phongs");
            DropTable("dbo.DichVus");
            DropTable("dbo.PhongSuDungDichVus");
            DropTable("dbo.DatPhongThatBais");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DatPhongThanhCongs");
        }
    }
}
