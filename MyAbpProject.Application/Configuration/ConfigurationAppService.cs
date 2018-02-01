using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyAbpProject.Configuration.Dto;

namespace MyAbpProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyAbpProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
