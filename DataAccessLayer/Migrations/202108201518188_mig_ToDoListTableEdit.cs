namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ToDoListTableEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoLists", "Priority", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoLists", "Priority", c => c.String(maxLength: 10));
        }
    }
}
