export interface IThemeAssetContributor {
    getAssetUrls(): string[];
    getAdditionalBodyStyle(): string;
    getMenuWrapperStyle(): string;
    getFooterStyle(): string;
}
