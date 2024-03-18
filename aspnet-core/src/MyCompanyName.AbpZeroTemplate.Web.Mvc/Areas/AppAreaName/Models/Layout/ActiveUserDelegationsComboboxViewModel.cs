using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.Authorization.Delegation;
using MyCompanyName.AbpZeroTemplate.Authorization.Users.Delegation.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }

        public List<UserDelegationDto> UserDelegations { get; set; }

        public string CssClass { get; set; }
    }
}
