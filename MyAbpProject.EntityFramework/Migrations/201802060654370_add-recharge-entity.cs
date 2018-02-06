namespace MyAbpProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addrechargeentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RechargeFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncrementAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Integral = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RechargeField_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RechargeRecords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RechargeFieldId = c.Int(nullable: false),
                        RechargeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncrementAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Integral = c.Double(nullable: false),
                        StoreNumber = c.String(),
                        SalesManNumber = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RechargeRecord_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RechargeFields", t => t.RechargeFieldId, cascadeDelete: true)
                .Index(t => t.RechargeFieldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RechargeRecords", "RechargeFieldId", "dbo.RechargeFields");
            DropIndex("dbo.RechargeRecords", new[] { "RechargeFieldId" });
            DropTable("dbo.RechargeRecords",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RechargeRecord_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.RechargeFields",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RechargeField_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
