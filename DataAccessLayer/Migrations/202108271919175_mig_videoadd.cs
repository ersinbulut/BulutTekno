namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_videoadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        VideoTitle = c.String(),
                        VideoDescription = c.String(),
                        VideoDate = c.DateTime(nullable: false),
                        WriterID = c.Int(),
                        VideoStatus = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.WriterUsers", t => t.WriterID)
                .Index(t => t.WriterID)
                .Index(t => t.CategoryID);
            
            AddColumn("dbo.Comments", "VideoID", c => c.Int());
            CreateIndex("dbo.Comments", "VideoID");
            AddForeignKey("dbo.Comments", "VideoID", "dbo.Videos", "VideoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "WriterID", "dbo.WriterUsers");
            DropForeignKey("dbo.Comments", "VideoID", "dbo.Videos");
            DropForeignKey("dbo.Videos", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Videos", new[] { "CategoryID" });
            DropIndex("dbo.Videos", new[] { "WriterID" });
            DropIndex("dbo.Comments", new[] { "VideoID" });
            DropColumn("dbo.Comments", "VideoID");
            DropTable("dbo.Videos");
        }
    }
}
