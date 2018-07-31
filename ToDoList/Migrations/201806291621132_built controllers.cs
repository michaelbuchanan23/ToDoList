namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class builtcontrollers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lists", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Lists", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Lists", "UserId", c => c.String());
            AlterColumn("dbo.Lists", "Name", c => c.String());
        }
    }
}
