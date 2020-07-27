namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DatPhongThanhCongs", "IDKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.DatPhongThatBais", "MaDoan", "dbo.Doans");
            DropForeignKey("dbo.DatPhongThanhCongs", "IDPhong", "dbo.Phongs");
            DropIndex("dbo.DatPhongThanhCongs", new[] { "IDKhachHang" });
            DropIndex("dbo.DatPhongThanhCongs", new[] { "IDPhong" });
            DropIndex("dbo.DatPhongThatBais", new[] { "MaDoan" });
            CreateTable(
                "dbo.UserMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserPassword = c.String(nullable: false, maxLength: 50),
                        UserRoles = c.String(nullable: false, maxLength: 500),
                        UserEmailID = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        UserID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.KhachHangs", "IDPhong", c => c.Int(nullable: false));
            AddColumn("dbo.Doans", "TrangThaiDatPhong", c => c.Int(nullable: false));
            AddColumn("dbo.Doans", "TrangThaiXacNhan", c => c.Boolean(nullable: false));
            AlterColumn("dbo.KhachHangs", "HoVaTen", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.KhachHangs", "SoDienThoai", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.KhachHangs", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Doans", "TenDoan", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Doans", "TenTruongDoan", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Phongs", "LoaiPhong", c => c.Int(nullable: false));
            DropTable("dbo.DatPhongThanhCongs");
            DropTable("dbo.DatPhongThatBais");
            DropTable("dbo.TaiKhoans");
        }
        
        public override void Down()
        {
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
                "dbo.DatPhongThatBais",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDoan = c.String(nullable: false, maxLength: 200),
                        MaDoan = c.String(nullable: false, maxLength: 50),
                        GhiChu = c.String(maxLength: 2000),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DatPhongThanhCongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDKhachHang = c.Int(nullable: false),
                        IDPhong = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        NgayTraPhongThucTe = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TrangThaiDatPhong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Phongs", "LoaiPhong", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Doans", "TenTruongDoan", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Doans", "TenDoan", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KhachHangs", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KhachHangs", "SoDienThoai", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.KhachHangs", "HoVaTen", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Doans", "TrangThaiXacNhan");
            DropColumn("dbo.Doans", "TrangThaiDatPhong");
            DropColumn("dbo.KhachHangs", "IDPhong");
            DropTable("dbo.UserMasters");
            CreateIndex("dbo.DatPhongThatBais", "MaDoan");
            CreateIndex("dbo.DatPhongThanhCongs", "IDPhong");
            CreateIndex("dbo.DatPhongThanhCongs", "IDKhachHang");
            AddForeignKey("dbo.DatPhongThanhCongs", "IDPhong", "dbo.Phongs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DatPhongThatBais", "MaDoan", "dbo.Doans", "MaDoan", cascadeDelete: true);
            AddForeignKey("dbo.DatPhongThanhCongs", "IDKhachHang", "dbo.KhachHangs", "ID", cascadeDelete: true);
        }
    }
}
