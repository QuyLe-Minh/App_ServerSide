using MyCompanyName.AbpZeroTemplate.Editions.Dto;

namespace MyCompanyName.AbpZeroTemplate.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < AbpZeroTemplateConsts.MinimumUpgradePaymentAmount;
        }
    }
}
