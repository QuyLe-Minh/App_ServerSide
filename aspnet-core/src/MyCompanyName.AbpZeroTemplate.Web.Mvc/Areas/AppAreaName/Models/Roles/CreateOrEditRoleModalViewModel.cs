using Abp.AutoMapper;
using MyCompanyName.AbpZeroTemplate.Authorization.Roles.Dto;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}