namespace QLKSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update266 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenDoan = c.String(nullable: false, maxLength: 50),
                        NgayGui = c.DateTime(nullable: false),
                        TenTruongDoan = c.String(nullable: false, maxLength: 50),
                        MaDoan = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.KhachHangs", "NgayGui", c => c.DateTime());
            AddColumn("dbo.KhachHangs", "TenTruongDoan", c => c.String());
            AddColumn("dbo.KhachHangs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.KhachHangs", "Doan_ID", c => c.Int());
            AddColumn("dbo.Phongs", "Doan_ID", c => c.Int());
            CreateIndex("dbo.KhachHangs", "Doan_ID");
            CreateIndex("dbo.Phongs", "Doan_ID");
            AddForeignKey("dbo.KhachHangs", "Doan_ID", "dbo.Doans", "ID");
            AddForeignKey("dbo.Phongs", "Doan_ID", "dbo.Doans", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phongs", "Doan_ID", "dbo.Doans");
            DropForeignKey("dbo.KhachHangs", "Doan_ID", "dbo.Doans");
            DropIndex("dbo.Phongs", new[] { "Doan_ID" });
            DropIndex("dbo.KhachHangs", new[] { "Doan_ID" });
            DropColumn("dbo.Phongs", "Doan_ID");
            DropColumn("dbo.KhachHangs", "Doan_ID");
            DropColumn("dbo.KhachHangs", "Discriminator");
            DropColumn("dbo.KhachHangs", "TenTruongDoan");
            DropColumn("dbo.KhachHangs", "NgayGui");
            DropTable("dbo.Doans");
        }
    }
}
