using System.Threading.Tasks;
using Abp.Application.Services;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments.Dto;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments.Stripe.Dto;

namespace MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}