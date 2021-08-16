namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Admin_Class_Poroperty_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Salt", c => c.String());
            AddColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminStatus");
            DropColumn("dbo.Admins", "Salt");
        }
    }
}
