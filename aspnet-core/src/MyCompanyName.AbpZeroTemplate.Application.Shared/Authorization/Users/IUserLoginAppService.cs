using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Authorization.Users.Dto;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<PagedResultDto<UserLoginAttemptDto>> GetUserLoginAttempts(GetLoginAttemptsInput input);
    }
}
