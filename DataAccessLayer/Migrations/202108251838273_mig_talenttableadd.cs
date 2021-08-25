namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talenttableadd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Talents", name: "WriterUser_WriterID", newName: "WriterID");
            RenameIndex(table: "dbo.Talents", name: "IX_WriterUser_WriterID", newName: "IX_WriterID");
            DropColumn("dbo.Talents", "WriterUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talents", "WriterUserID", c => c.Int());
            RenameIndex(table: "dbo.Talents", name: "IX_WriterID", newName: "IX_WriterUser_WriterID");
            RenameColumn(table: "dbo.Talents", name: "WriterID", newName: "WriterUser_WriterID");
        }
    }
}
