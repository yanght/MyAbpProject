using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNet.Identity;
using MyAbpProject.Roles.Dto;
using MyAbpProject.Users.Dto;

namespace MyAbpProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        PagedResultDto<UserDto> GetUserByPage(GetUsersInput input);

        Task<IdentityResult> ChangeUserStatus(EntityDto<long> input);
    }
}