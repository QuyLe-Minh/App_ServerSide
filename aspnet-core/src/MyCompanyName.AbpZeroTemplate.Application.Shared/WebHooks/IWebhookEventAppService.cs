using System.Threading.Tasks;
using Abp.Webhooks;

namespace MyCompanyName.AbpZeroTemplate.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
