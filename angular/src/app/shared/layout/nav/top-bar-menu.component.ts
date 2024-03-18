import { PermissionCheckerService } from 'abp-ng2-module';
import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { NavigationEnd, NavigationCancel, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AppMenu } from './app-menu';
import { AppNavigationService } from './app-navigation.service';
import * as objectPath from 'object-path';
import { filter } from 'rxjs/operators';
import { ThemeAssetContributorFactory } from '@shared/helpers/ThemeAssetContributorFactory';
import { MenuComponent, DrawerComponent, ToggleComponent, ScrollComponent } from '@metronic/app/kt/components';

@Component({
    templateUrl: './top-bar-menu.component.html',
    selector: 'top-bar-menu',
    encapsulation: ViewEncapsulation.None,
})
export class TopBarMenuComponent extends AppComponentBase implements OnInit {
    menu: AppMenu = null;
    currentRouteUrl: any = '';
    menuDepth: 0;
    menuWrapperStyle = '';

    constructor(
        injector: Injector,
        private router: Router,
        public permission: PermissionCheckerService,
        private _appNavigationService: AppNavigationService
    ) {
        super(injector);
    }

    ngOnInit() {
        this.menu = this._appNavigationService.getMenu();
        this.currentRouteUrl = this.router.url;
        this.menuWrapperStyle = ThemeAssetContributorFactory.getCurrent().getMenuWrapperStyle();

        this.router.events.pipe(filter((event) => event instanceof NavigationEnd)).subscribe((event) => {
            this.currentRouteUrl = this.router.url;
        });

        this.router.events
            .pipe(filter((event) => event instanceof NavigationEnd || event instanceof NavigationCancel))
            .subscribe((event) => {
                this.reinitializeMenu();
            });
    }

    reinitializeMenu(): void {
        setTimeout(() => {
            MenuComponent.reinitialization();
            DrawerComponent.reinitialization();
            ToggleComponent.reinitialization();
            ScrollComponent.reinitialization();
        }, 50);
    }

    showMenuItem(menuItem): boolean {
        return this._appNavigationService.showMenuItem(menuItem);
    }

    getItemCssClasses(item, parentItem, depth) {
        let cssClasses = 'menu-item';

        if (objectPath.get(item, 'icon-only')) {
            cssClasses += ' menu-item-icon-only';
        }

        return cssClasses;
    }

    getAnchorItemCssClasses(item, parentItem): string {
        let cssClasses = 'menu-link without-sub';

        return cssClasses;
    }

    getSubmenuCssClasses(item, parentItem, depth): string {
        return 'menu-sub menu-sub-lg-down-accordion menu-sub-lg-dropdown menu-rounded-0 py-lg-4 w-lg-225px';
    }

    isMenuItemIsActive(item): boolean {
        if (item.items.length) {
            return this.isMenuRootItemIsActive(item);
        }

        if (!item.route) {
            return false;
        }

        return this.currentRouteUrl.replace(/\/$/, '') === item.route.replace(/\/$/, '');
    }

    isMenuRootItemIsActive(item): boolean {
        if (item.items) {
            for (const subItem of item.items) {
                if (this.isMenuItemIsActive(subItem)) {
                    return true;
                }
            }
        }

        return false;
    }

    getItemAttrSubmenuToggle(menuItem, parentItem, depth) {
        if (depth && depth >= 1) {
            return 'hover';
        } else {
            return 'click';
        }
    }

    isMobileDevice(): any {
        return KTUtil.isMobileDevice();
    }
}
