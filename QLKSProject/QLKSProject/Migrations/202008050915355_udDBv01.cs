namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udDBv01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LichSuDichVus", "SoPhong", c => c.String(nullable: false));
            AddColumn("dbo.LichSuDichVus", "TenDichVu", c => c.String(nullable: false));
            AddColumn("dbo.LichSuDichVus", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.LichSuDichVus", "HoVaTenKhachHang", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LichSuDichVus", "HoVaTenKhachHang");
            DropColumn("dbo.LichSuDichVus", "IsDelete");
            DropColumn("dbo.LichSuDichVus", "TenDichVu");
            DropColumn("dbo.LichSuDichVus", "SoPhong");
        }
    }
}
