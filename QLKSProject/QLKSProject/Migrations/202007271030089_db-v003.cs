namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "TrangThaiXacNhan", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHangs", "TrangThaiXacNhan");
        }
    }
}
