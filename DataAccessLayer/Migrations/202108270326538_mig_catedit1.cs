namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_catedit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Count");
        }
    }
}
