namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_blogtableadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        BlogTitle = c.String(),
                        BlogDescription = c.String(),
                        BlogDate = c.DateTime(nullable: false),
                        WriterID = c.Int(),
                        BlogStatus = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.WriterUsers", t => t.WriterID)
                .Index(t => t.WriterID)
                .Index(t => t.CategoryID);
            
            AddColumn("dbo.Comments", "BlogID", c => c.Int());
            CreateIndex("dbo.Comments", "BlogID");
            AddForeignKey("dbo.Comments", "BlogID", "dbo.Blogs", "BlogID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "WriterID", "dbo.WriterUsers");
            DropForeignKey("dbo.Comments", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "BlogID" });
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropIndex("dbo.Blogs", new[] { "WriterID" });
            DropColumn("dbo.Comments", "BlogID");
            DropTable("dbo.Blogs");
        }
    }
}
