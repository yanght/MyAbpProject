using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpProject.Sessions.Dto;

namespace MyAbpProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
