namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminedit : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Admins", newName: "AdminUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AdminUsers", newName: "Admins");
        }
    }
}
