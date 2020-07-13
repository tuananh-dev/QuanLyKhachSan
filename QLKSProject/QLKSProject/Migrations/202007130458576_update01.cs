namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TienIches", "MoTa", c => c.String(nullable: false));
            DropColumn("dbo.TienIches", "HinhAnh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TienIches", "HinhAnh", c => c.String(nullable: false));
            DropColumn("dbo.TienIches", "MoTa");
        }
    }
}
