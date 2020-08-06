namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ubdbv03 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Phongs", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phongs", "TrangThai", c => c.Boolean(nullable: false));
        }
    }
}
