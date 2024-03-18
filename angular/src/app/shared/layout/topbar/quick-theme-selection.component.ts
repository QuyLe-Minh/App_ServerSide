import { Component, Injector, Input } from '@angular/core';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { ThemesLayoutBaseComponent } from '../themes/themes-layout-base.component';

@Component({
    selector: 'quick-theme-selection',
    templateUrl: './quick-theme-selection.component.html',
})
export class QuickThemeSelectionComponent extends ThemesLayoutBaseComponent {
    isQuickThemeSelectEnabled: boolean = this.setting.getBoolean('App.UserManagement.IsQuickThemeSelectEnabled');

    @Input() customStyle = 'btn btn-icon btn-active-light-primary w-30px h-30px w-md-40px h-md-40px';
    @Input() iconStyle = 'flaticon-interface-7 fs-4';

    public constructor(injector: Injector, _dateTimeService: DateTimeService) {
        super(injector, _dateTimeService);
    }
}
