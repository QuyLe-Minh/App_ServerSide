using MyCompanyName.AbpZeroTemplate.DashboardCustomization;
using MyCompanyName.AbpZeroTemplate.DashboardCustomization.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.CustomizableDashboard
{
    public class CustomizableDashboardViewModel
    {
        public DashboardOutput DashboardOutput { get; }

        public Dashboard UserDashboard { get; }

        public CustomizableDashboardViewModel(
            DashboardOutput dashboardOutput,
            Dashboard userDashboard)
        {
            DashboardOutput = dashboardOutput;
            UserDashboard = userDashboard;
        }
    }
}