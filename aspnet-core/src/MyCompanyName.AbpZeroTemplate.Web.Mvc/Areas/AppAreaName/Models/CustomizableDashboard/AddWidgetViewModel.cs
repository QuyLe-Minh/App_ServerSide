using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.DashboardCustomization.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
