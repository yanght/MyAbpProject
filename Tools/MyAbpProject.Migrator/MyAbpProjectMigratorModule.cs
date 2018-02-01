using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MyAbpProject.EntityFramework;

namespace MyAbpProject.Migrator
{
    [DependsOn(typeof(MyAbpProjectDataModule))]
    public class MyAbpProjectMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MyAbpProjectDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}