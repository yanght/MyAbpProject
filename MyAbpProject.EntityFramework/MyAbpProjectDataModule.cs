using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using Abp.Dapper;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using MyAbpProject.EntityFramework;

namespace MyAbpProject
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule),
        typeof(MyAbpProjectCoreModule),
        typeof(AbpDapperModule)
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

            //这里会自动去扫描程序集中配置好的映射关系
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { Assembly.GetExecutingAssembly() });

        }
    }
}
