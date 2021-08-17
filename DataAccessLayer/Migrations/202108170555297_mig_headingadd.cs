namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headingadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "Slider", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "Slider");
        }
    }
}
