namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_content_propadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ImageUrl1", c => c.String(maxLength: 200));
            AddColumn("dbo.Contents", "ImageUrl2", c => c.String(maxLength: 200));
            AddColumn("dbo.Contents", "ImageUrl3", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ImageUrl3");
            DropColumn("dbo.Contents", "ImageUrl2");
            DropColumn("dbo.Contents", "ImageUrl1");
        }
    }
}
