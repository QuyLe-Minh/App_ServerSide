using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.MultiTenancy;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Layout;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Startup;
using MyCompanyName.AbpZeroTemplate.Web.Views;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameMenu
{
    public class AppAreaNameMenuViewComponent : AbpZeroTemplateViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;
        private readonly TenantManager _tenantManager;

        public AppAreaNameMenuViewComponent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession,
            TenantManager tenantManager)
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
            _tenantManager = tenantManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLeftMenuUsed">set to true for rendering left aside menu</param>
        /// <param name="iconMenu">set to render main menu items as icons. Only valid for left menu</param>
        /// <param name="currentPageName">Name of the current pagae</param>
        /// <param name="height">height of the menu</param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(bool isLeftMenuUsed, bool iconMenu = false, string currentPageName = null, string height = "auto")
        {
            var model = new MenuViewModel
            {
                Menu = await _userNavigationManager.GetMenuAsync(AppAreaNameNavigationProvider.MenuName, _abpSession.ToUserIdentifier()),
                Height = height,
                CurrentPageName = currentPageName,
                IconMenu = iconMenu
            };

            if (AbpSession.TenantId == null)
            {
                return GetView(model, isLeftMenuUsed);
            }

            var tenant = await _tenantManager.GetByIdAsync(AbpSession.TenantId.Value);
            if (tenant.EditionId.HasValue)
            {
                return GetView(model, isLeftMenuUsed);
            }

            var subscriptionManagement = FindMenuItemOrNull(model.Menu.Items, AppAreaNamePageNames.Tenant.SubscriptionManagement);
            if (subscriptionManagement != null)
            {
                subscriptionManagement.IsVisible = false;
            }

            return GetView(model, isLeftMenuUsed);
        }

        public UserMenuItem FindMenuItemOrNull(IList<UserMenuItem> userMenuItems, string name)
        {
            if (userMenuItems == null)
            {
                return null;
            }

            foreach (var menuItem in userMenuItems)
            {
                if (menuItem.Name == name)
                {
                    return menuItem;
                }

                var found = FindMenuItemOrNull(menuItem.Items, name);
                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        private IViewComponentResult GetView(MenuViewModel model, bool isLeftMenuUsed)
        {
            return View(isLeftMenuUsed ? "Default" : "Top", model);
        }
    }
}
