namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignedPersonId = c.Long(),
                        Title = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false),
                        State = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedPersonId)
                .Index(t => t.AssignedPersonId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "AssignedPersonId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "AssignedPersonId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
