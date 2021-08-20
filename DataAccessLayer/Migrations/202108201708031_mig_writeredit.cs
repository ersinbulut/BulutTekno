namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writeredit : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Writers", newName: "WriterUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.WriterUsers", newName: "Writers");
        }
    }
}
