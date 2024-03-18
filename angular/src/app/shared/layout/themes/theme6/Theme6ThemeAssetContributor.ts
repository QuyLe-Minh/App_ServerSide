import { IThemeAssetContributor } from '../ThemeAssetContributor';
import { AppConsts } from '@shared/AppConsts';

export class Theme6ThemeAssetContributor implements IThemeAssetContributor {
    public getAssetUrls(): string[] {
        return [AppConsts.appBaseUrl + '/assets/fonts/fonts-montserrat.min.css'];
    }

    public getAdditionalBodyStyle(): string {
        return '';
    }

    public getMenuWrapperStyle(): string {
        return 'header-menu-wrapper header-menu-wrapper-left py-lg-2';
    }

    public getSubheaderStyle(): string {
        return 'text-dark font-weight-bold my-1 me-5';
    }

    public getFooterStyle(): string {
        return 'footer py-5 d-flex flex-lg-column';
    }
}
