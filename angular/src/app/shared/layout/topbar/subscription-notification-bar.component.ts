import { Component, Injector, Input } from '@angular/core';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { ThemesLayoutBaseComponent } from '../themes/themes-layout-base.component';

@Component({
    selector: 'subscription-notification-bar',
    templateUrl: './subscription-notification-bar.component.html',
})
export class SubscriptionNotificationBarComponent extends ThemesLayoutBaseComponent {
    
    @Input() customStyle = 'btn btn-icon btn-active-light-primary position-relative w-30px h-30px w-md-40px h-md-40px me-2';

    public constructor(injector: Injector, _dateTimeService: DateTimeService) {
        super(injector, _dateTimeService);
    }
}
