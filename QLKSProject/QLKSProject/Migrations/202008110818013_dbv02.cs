namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phongs", "SoPhong", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phongs", "SoPhong", c => c.String(nullable: false, maxLength: 3));
        }
    }
}
