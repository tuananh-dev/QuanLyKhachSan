namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatev001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DanhSachFileGuis", "DatPhongThanhCong_ID", "dbo.DatPhongThanhCongs");
            DropForeignKey("dbo.KhachHangs", "DanhSachFileGui_ID", "dbo.DanhSachFileGuis");
            DropIndex("dbo.DanhSachFileGuis", new[] { "DatPhongThanhCong_ID" });
            DropIndex("dbo.KhachHangs", new[] { "DanhSachFileGui_ID" });
            AddColumn("dbo.KhachHangs", "TenDoan", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.KhachHangs", "DanhSachFileGui_ID");
            DropTable("dbo.DanhSachFileGuis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DanhSachFileGuis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDanhSach = c.String(nullable: false, maxLength: 50),
                        TenTruongDoan = c.String(nullable: false, maxLength: 50),
                        NgayGui = c.DateTime(nullable: false),
                        MaDoan = c.String(nullable: false, maxLength: 50),
                        DatPhongThanhCong_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.KhachHangs", "DanhSachFileGui_ID", c => c.Int());
            DropColumn("dbo.KhachHangs", "TenDoan");
            CreateIndex("dbo.KhachHangs", "DanhSachFileGui_ID");
            CreateIndex("dbo.DanhSachFileGuis", "DatPhongThanhCong_ID");
            AddForeignKey("dbo.KhachHangs", "DanhSachFileGui_ID", "dbo.DanhSachFileGuis", "ID");
            AddForeignKey("dbo.DanhSachFileGuis", "DatPhongThanhCong_ID", "dbo.DatPhongThanhCongs", "ID");
        }
    }
}
