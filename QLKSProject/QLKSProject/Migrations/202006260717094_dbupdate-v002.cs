namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdatev002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doans", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doans", "IsDelete");
        }
    }
}
