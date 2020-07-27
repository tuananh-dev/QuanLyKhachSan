namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv005 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserMasters", "MaDoan", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMasters", "MaDoan", c => c.String());
        }
    }
}
