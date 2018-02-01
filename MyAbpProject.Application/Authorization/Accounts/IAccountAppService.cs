using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpProject.Authorization.Accounts.Dto;

namespace MyAbpProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
