namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydb2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30),
                        ferstname = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        email = c.String(maxLength: 30),
                        Password = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
