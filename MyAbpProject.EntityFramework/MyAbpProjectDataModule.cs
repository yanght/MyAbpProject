using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using MyAbpProject.EntityFramework;

namespace MyAbpProject
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule),
        typeof(MyAbpProjectCoreModule)
          )]
    public class MyAbpProjectDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyAbpProjectDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
