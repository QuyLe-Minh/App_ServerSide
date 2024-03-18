import { Component, Injector, OnInit, Input } from '@angular/core';
import { ThemesLayoutBaseComponent } from '../themes/themes-layout-base.component';
import { AbpSessionService } from 'abp-ng2-module';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'chat-toggle-button',
    templateUrl: './chat-toggle-button.component.html',
})
export class ChatToggleButtonComponent extends ThemesLayoutBaseComponent implements OnInit {
    unreadChatMessageCount = 0;
    chatConnected = false;
    isHost = false;

    @Input() customStyle = 'btn btn-icon btn-active-light-primary position-relative w-30px h-30px w-md-40px h-md-40px me-2';
    @Input() iconStyle = 'flaticon-chat-2 fs-4';

    public constructor(
        injector: Injector,
        private _abpSessionService: AbpSessionService,
        _dateTimeService: DateTimeService
    ) {
        super(injector, _dateTimeService);
    }

    ngOnInit(): void {
        this.registerToEvents();
        this.isHost = !this._abpSessionService.tenantId;
    }

    registerToEvents() {
        this.subscribeToEvent('app.chat.unreadMessageCountChanged', (messageCount) => {
            this.unreadChatMessageCount = messageCount;
        });

        this.subscribeToEvent('app.chat.connected', () => {
            this.chatConnected = true;
        });
    }
}
