using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;

namespace MyCompanyName.AbpZeroTemplate.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
