using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.DynamicEntityProperties.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.DynamicEntityProperty
{
    public class CreateEntityDynamicPropertyViewModel
    {
        public string EntityFullName { get; set; }

        public List<string> AllEntities { get; set; }

        public List<DynamicPropertyDto> DynamicProperties { get; set; }
    }
}
