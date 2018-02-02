using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using MyProject.MultiTenancy;
using MyProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
    {
        public FeatureValueStore(
             ICacheManager cacheManager,
             IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
             IRepository<Tenant> tenantRepository,
             IRepository<EditionFeatureSetting, long> editionFeatureRepository,
             IFeatureManager featureManager,
             IUnitOfWorkManager unitOfWorkManager)
             : base(cacheManager,
                   tenantFeatureRepository,
                   tenantRepository,
                   editionFeatureRepository,
                   featureManager,
                   unitOfWorkManager)
        {
        }
    }
}
