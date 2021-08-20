namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ToDoListTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        ToDoID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Priority = c.String(maxLength: 10),
                        ToDoDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(maxLength: 250),
                        ToDoStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoLists");
        }
    }
}
