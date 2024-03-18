using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.WebHooks.Dto;

namespace MyCompanyName.AbpZeroTemplate.WebHooks
{
    public interface IWebhookAttemptAppService
    {
        Task<PagedResultDto<GetAllSendAttemptsOutput>> GetAllSendAttempts(GetAllSendAttemptsInput input);

        Task<ListResultDto<GetAllSendAttemptsOfWebhookEventOutput>> GetAllSendAttemptsOfWebhookEvent(GetAllSendAttemptsOfWebhookEventInput input);
    }
}
