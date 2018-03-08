using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MyAbpProject.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace MyAbpProject.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MyAbpProject.EntityFramework.MyAbpProjectDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyAbpProject";
        }

        protected override void Seed(MyAbpProject.EntityFramework.MyAbpProjectDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
                new DefaultRechargeFieldCreateor(context).Create();
               // new DefaultPermissionDefinedCreator(context).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
