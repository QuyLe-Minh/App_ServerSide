import { AppConsts } from '@shared/AppConsts';
import * as rtlDetect from 'rtl-detect';
import { StyleLoaderService } from '@shared/utils/style-loader.service';
import { ThemeHelper } from '@app/shared/layout/themes/ThemeHelper';
import { ThemeAssetContributorFactory } from './ThemeAssetContributorFactory';

export class DynamicResourcesHelper {
    static loadResources(callback: () => void): void {
        Promise.all([DynamicResourcesHelper.loadStyles()]).then(() => {
            callback();
        });
    }

    static loadStyles(): Promise<any> {
        let theme = ThemeHelper.getTheme();

        const isRtl = rtlDetect.isRtlLang(abp.localization.currentLanguage.name);

        if (isRtl) {
            document.documentElement.setAttribute('dir', 'rtl');
        }

        const cssPrefix = ThemeHelper.darkMode() ? '.dark' : '';
        const cssPostfix = isRtl ? '.rtl' : '';
        const styleLoaderService = new StyleLoaderService();

        let styleUrls = [
            AppConsts.appBaseUrl +
                '/assets/metronic/themes/' +
                theme +
                '/css/style' +
                cssPrefix +
                '.bundle' +
                cssPostfix.replace('-', '.') +
                '.min.css',
            AppConsts.appBaseUrl +
                '/assets/metronic/themes/' +
                theme +
                '/plugins/global/plugins' +
                cssPrefix +
                '.bundle' +
                cssPostfix.replace('-', '.') +
                '.min.css',
            AppConsts.appBaseUrl +
                '/assets/primeng/themes/mdc-' +
                (ThemeHelper.darkMode() ? 'dark' : 'light') +
                '-indigo/theme.css', // PrimeNG Dark mode styles
            AppConsts.appBaseUrl + '/assets/primeng/datatable/css/primeng.datatable' + cssPostfix + '.min.css', // PrimeNG RTL styles
            AppConsts.appBaseUrl + '/assets/common/styles/metronic-customize.min.css',
            AppConsts.appBaseUrl + '/assets/common/styles/themes/' + theme + '/metronic-customize.min.css',
            AppConsts.appBaseUrl + '/assets/common/styles/metronic-customize-angular.min.css',
        ].concat(DynamicResourcesHelper.getAdditionalThemeAssets());

        styleLoaderService.loadArray(styleUrls);

        if (isRtl) {
            styleLoaderService.load(AppConsts.appBaseUrl + '/assets/common/styles/abp-zero-template-rtl.min.css');
        }

        return Promise.resolve(true);
    }

    static getAdditionalThemeAssets(): string[] {
        let assetContributor = ThemeAssetContributorFactory.getCurrent();
        if (!assetContributor) {
            return [];
        }

        return assetContributor.getAssetUrls();
    }
}
