﻿namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetienich : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TienIches", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TienIches", "IsDelete");
        }
    }
}
