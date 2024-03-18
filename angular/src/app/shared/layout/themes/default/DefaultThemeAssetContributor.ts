import { IThemeAssetContributor } from '../ThemeAssetContributor';

export class DefaultThemeAssetContributor implements IThemeAssetContributor {
    public getAssetUrls(): string[] {
        return [
        ];
    }

    public getAdditionalBodyStyle(): string {
        return '';
    }

    public getMenuWrapperStyle(): string {
        return 'header-menu-wrapper header-menu-wrapper-left';
    }

    public getSubheaderStyle(): string {
        return 'text-dark font-weight-bold my-1 me-5';
    }

    public getFooterStyle(): string {
        return 'footer py-4 d-flex flex-lg-column';
    }
}
