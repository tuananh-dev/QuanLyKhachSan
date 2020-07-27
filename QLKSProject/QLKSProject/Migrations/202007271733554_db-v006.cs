namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv006 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHangs", "NguoiDaiDienCuaTreEm", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHangs", "NguoiDaiDienCuaTreEm", c => c.String(maxLength: 100));
        }
    }
}
