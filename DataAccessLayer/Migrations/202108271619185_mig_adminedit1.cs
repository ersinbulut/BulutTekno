namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminedit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminUsers", "AdminImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdminUsers", "AdminImage");
        }
    }
}
