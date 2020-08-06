namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ubDBv02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHangs", "TrangThaiDatPhong", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHangs", "TrangThaiDatPhong", c => c.Boolean(nullable: false));
        }
    }
}
