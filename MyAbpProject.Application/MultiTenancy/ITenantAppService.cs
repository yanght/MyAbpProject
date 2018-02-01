using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyAbpProject.MultiTenancy.Dto;

namespace MyAbpProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
