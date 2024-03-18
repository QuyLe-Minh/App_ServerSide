export class ThemeHelper {
    public static getTheme(): string {
        return abp.setting.get('App.UiManagement.Theme');
    }

    public static darkMode(): boolean {
        return abp.setting.get(ThemeHelper.getTheme() + '.App.UiManagement.DarkMode')?.toLowerCase() === "true";
    }
}
