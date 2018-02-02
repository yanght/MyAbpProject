using Abp.Authorization.Users;
using MyProject.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Abp.Domain.Repositories;
using Abp.Configuration.Startup;
using Abp.Authorization;
using Abp.Domain.Uow;
using Abp.Configuration;
using Abp.Zero.Configuration;
using Abp.Dependency;
using Abp.Runtime.Caching;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Organizations;
using MyProject.Authorization.Roles;

namespace MyProject.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            UserStore userStore,
            RoleManager roleManager,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            ILocalizationManager localizationManager,
            ISettingManager settingManager,
            IdentityEmailMessageService emailService,
            IUserTokenProviderAccessor userTokenProviderAccessor)
            : base(
                  userStore,
                  roleManager,
                  permissionManager,
                  unitOfWorkManager,
                  cacheManager,
                  organizationUnitRepository,
                  userOrganizationUnitRepository,
                  organizationUnitSettings,
                  localizationManager,
                  emailService,
                  settingManager,
                  userTokenProviderAccessor)
        {

        }
    }
}
