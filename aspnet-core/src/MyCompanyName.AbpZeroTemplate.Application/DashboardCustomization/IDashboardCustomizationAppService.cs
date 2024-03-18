using System.Collections.Generic;
using Abp.Application.Services;
using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.DashboardCustomization.Dto;

namespace MyCompanyName.AbpZeroTemplate.DashboardCustomization
{
    public interface IDashboardCustomizationAppService : IApplicationService
    {
        Task<Dashboard> GetUserDashboard(GetDashboardInput input);

        Task SavePage(SavePageInput input);

        Task RenamePage(RenamePageInput input);

        Task<AddNewPageOutput> AddNewPage(AddNewPageInput input);

        Task<Widget> AddWidget(AddWidgetInput input);

        Task DeletePage(DeletePageInput input);

        DashboardOutput GetDashboardDefinition(GetDashboardInput input);

        List<WidgetOutput> GetAllWidgetDefinitions(GetDashboardInput input);

        Task<List<WidgetOutput>> GetAllAvailableWidgetDefinitionsForPage(GetAvailableWidgetDefinitionsForPageInput input);
    }
}
