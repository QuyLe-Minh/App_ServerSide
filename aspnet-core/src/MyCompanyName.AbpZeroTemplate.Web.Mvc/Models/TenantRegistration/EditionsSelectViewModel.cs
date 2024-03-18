using Abp.AutoMapper;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
