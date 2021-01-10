namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 30));
            DropColumn("dbo.Users", "LastNameName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "LastNameName", c => c.String(maxLength: 30));
            DropColumn("dbo.Users", "LastName");
        }
    }
}
