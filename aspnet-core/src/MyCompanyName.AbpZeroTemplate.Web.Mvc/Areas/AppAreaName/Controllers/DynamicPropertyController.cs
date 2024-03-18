using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.DynamicEntityProperties;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.DynamicEntityProperties;
using MyCompanyName.AbpZeroTemplate.DynamicEntityProperties.Dto;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.DynamicProperty;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    public class DynamicPropertyController : AbpZeroTemplateControllerBase
    {
        private readonly IDynamicPropertyAppService _dynamicPropertyAppService;
        private readonly IDynamicEntityPropertyDefinitionManager _dynamicEntityPropertyDefinitionManager;
        private readonly IDynamicEntityPropertyAppService _dynamicEntityPropertyAppService;

        public DynamicPropertyController(
            IDynamicPropertyAppService dynamicPropertyAppService,
            IDynamicEntityPropertyDefinitionManager dynamicEntityPropertyDefinitionManager,
            IDynamicEntityPropertyAppService dynamicEntityPropertyAppService)
        {
            _dynamicPropertyAppService = dynamicPropertyAppService;
            _dynamicEntityPropertyDefinitionManager = dynamicEntityPropertyDefinitionManager;
            _dynamicEntityPropertyAppService = dynamicEntityPropertyAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_DynamicProperties_Edit, AppPermissions.Pages_Administration_DynamicProperties_Create)]
        public async Task<IActionResult> CreateOrEditModal(int? id)
        {
            var model = new CreateOrEditDynamicPropertyViewModel
            {
                AllowedInputTypes = _dynamicEntityPropertyDefinitionManager.GetAllAllowedInputTypeNames()
            };

            if (id.HasValue)
            {
                model.DynamicPropertyDto = await _dynamicPropertyAppService.Get(id.Value);
            }
            else
            {
                model.DynamicPropertyDto = new DynamicPropertyDto();
            }

            return PartialView("_CreateOrEditModal", model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_DynamicPropertyValue_Edit, AppPermissions.Pages_Administration_DynamicPropertyValue_Create)]
        public async Task<IActionResult> ManageValuesModal(int id)
        {
            var dynamicProperty = await _dynamicPropertyAppService.Get(id);
            return PartialView("_ManageValuesModal", dynamicProperty);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_DynamicPropertyValue_Edit, AppPermissions.Pages_Administration_DynamicPropertyValue_Create)]
        public async Task<IActionResult> SelectAnEntityModal()
        {
            var allEntities = _dynamicEntityPropertyDefinitionManager.GetAllEntities();
            
            var entitiesAlreadyHasProperty =
                (await _dynamicEntityPropertyAppService.GetAllEntitiesHasDynamicProperty())
                .Items
                .Select(x => x.EntityFullName)
                .ToList();
            
            allEntities = allEntities.Except(entitiesAlreadyHasProperty).ToList();
            return PartialView("_SelectAnEntityModal", allEntities);
        }
    }
}