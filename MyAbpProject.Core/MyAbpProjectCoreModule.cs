using System.Reflection;
using Abp.Auditing;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using MyAbpProject.Authorization;
using MyAbpProject.Authorization.Roles;
using MyAbpProject.Authorization.Users;
using MyAbpProject.Configuration;
using MyAbpProject.MultiTenancy;

namespace MyAbpProject
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class MyAbpProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = MyAbpProjectConsts.MultiTenancyEnabled;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    MyAbpProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "MyAbpProject.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            #region [ register authorization provider ]

            Configuration.Authorization.Providers.Add<MyAbpProjectAuthorizationProvider>();
            //Configuration.Authorization.Providers.Add<UserAuthorizationProvider>();
            //Configuration.Authorization.Providers.Add<RoleAuthorizationProvider>();

            #endregion

            Configuration.Settings.Providers.Add<AppSettingProvider>();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
