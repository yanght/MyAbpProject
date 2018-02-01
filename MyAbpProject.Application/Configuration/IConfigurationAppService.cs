using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbpProject.Configuration.Dto;

namespace MyAbpProject.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}