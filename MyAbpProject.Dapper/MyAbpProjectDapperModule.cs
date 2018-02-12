using Abp.Dapper;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Dapper
{
    [DependsOn(typeof(AbpDapperModule),
      typeof(MyAbpProjectCoreModule)
        )]
    public class MyAbpProjectDapperModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
