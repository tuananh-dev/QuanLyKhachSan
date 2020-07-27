namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "GhiChu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHangs", "GhiChu");
        }
    }
}
