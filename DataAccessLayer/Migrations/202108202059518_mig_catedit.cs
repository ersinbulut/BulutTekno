namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_catedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ParentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ParentID");
        }
    }
}
