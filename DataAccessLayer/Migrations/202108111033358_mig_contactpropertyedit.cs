namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactpropertyedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Contacts", "NameMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "NameMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Contacts", "UserMail");
        }
    }
}
