using Abp.Application.Services.Dto;
using Abp.Webhooks;
using MyCompanyName.AbpZeroTemplate.WebHooks.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
