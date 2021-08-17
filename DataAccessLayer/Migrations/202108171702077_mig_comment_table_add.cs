namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_comment_table_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        ImageUrl = c.String(maxLength: 250),
                        CommentDate = c.DateTime(nullable: false),
                        CommentValue = c.String(),
                        ParentID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "WriterID", "dbo.Writers");
            DropIndex("dbo.Comments", new[] { "WriterID" });
            DropTable("dbo.Comments");
        }
    }
}
