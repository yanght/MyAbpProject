namespace MyAbpProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpermissondefined : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PermissionDefineds", "ParentId", "dbo.PermissionDefineds");
            DropIndex("dbo.PermissionDefineds", new[] { "ParentId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PermissionDefineds", "ParentId");
            AddForeignKey("dbo.PermissionDefineds", "ParentId", "dbo.PermissionDefineds", "Id");
        }
    }
}
