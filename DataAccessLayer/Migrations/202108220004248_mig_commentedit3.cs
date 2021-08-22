namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_commentedit3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contents", "CommentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "CommentID", c => c.Int());
        }
    }
}
