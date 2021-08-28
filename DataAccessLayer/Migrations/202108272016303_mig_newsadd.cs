namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_newsadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(),
                        NewsDescription = c.String(),
                        NewsDate = c.DateTime(nullable: false),
                        WriterID = c.Int(),
                        NewsStatus = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.WriterUsers", t => t.WriterID)
                .Index(t => t.WriterID)
                .Index(t => t.CategoryID);
            
            AddColumn("dbo.Comments", "NewsID", c => c.Int());
            CreateIndex("dbo.Comments", "NewsID");
            AddForeignKey("dbo.Comments", "NewsID", "dbo.News", "NewsID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "WriterID", "dbo.WriterUsers");
            DropForeignKey("dbo.Comments", "NewsID", "dbo.News");
            DropForeignKey("dbo.News", "CategoryID", "dbo.Categories");
            DropIndex("dbo.News", new[] { "CategoryID" });
            DropIndex("dbo.News", new[] { "WriterID" });
            DropIndex("dbo.Comments", new[] { "NewsID" });
            DropColumn("dbo.Comments", "NewsID");
            DropTable("dbo.News");
        }
    }
}
