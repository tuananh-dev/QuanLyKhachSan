namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMasters", "MaDoan", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMasters", "MaDoan");
        }
    }
}
