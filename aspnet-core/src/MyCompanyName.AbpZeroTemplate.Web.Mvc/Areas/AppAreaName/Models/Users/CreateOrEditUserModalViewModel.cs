using System.Linq;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using MyCompanyName.AbpZeroTemplate.Authorization.Users.Dto;
using MyCompanyName.AbpZeroTemplate.Security;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserForEditOutput))]
    public class CreateOrEditUserModalViewModel : GetUserForEditOutput, IOrganizationUnitsEditViewModel
    {
        public bool CanChangeUserName => User.UserName != AbpUserBase.AdminUserName;

        public int AssignedRoleCount
        {
            get { return Roles.Count(r => r.IsAssigned); }
        }

        public bool IsEditMode => User.Id.HasValue;

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }
    }
}