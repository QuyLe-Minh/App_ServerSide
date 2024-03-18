import { Injector, Component, ViewEncapsulation, Inject, Input, OnInit } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DOCUMENT } from '@angular/common';
import * as KTUtil from '@metronic/app/kt/_utils';

@Component({
    templateUrl: './default-logo.component.html',
    selector: 'default-logo',
    encapsulation: ViewEncapsulation.None,
})
export class DefaultLogoComponent extends AppComponentBase implements OnInit {
    defaultLogo = '';
    remoteServiceBaseUrl: string = AppConsts.remoteServiceBaseUrl;

    @Input() customHrefClass = '';
    @Input() skin = null;

    constructor(injector: Injector, @Inject(DOCUMENT) private document: Document) {
        super(injector);
    }

    ngOnInit(): void {
        this.setLogoUrl();
    }

    onResize() {
        this.setLogoUrl();
    }

    setLogoUrl(): void{
        var skinName = this.currentTheme.baseSettings.menu.asideSkin;
        if (KTUtil.isMobileDevice()) {
            skinName = this.currentTheme.baseSettings.layout.darkMode ? 'dark' : 'light';
        }

        this.defaultLogo = AppConsts.appBaseUrl + '/assets/common/images/app-logo-on-' + skinName + '.svg';
    }
}
