using Abp.Domain.Services;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Users.Password
{
    public interface IPasswordExpirationService : IDomainService
    {
        void ForcePasswordExpiredUsersToChangeTheirPassword();
    }
}
