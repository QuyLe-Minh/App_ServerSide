import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { AbpZeroTemplateCommonModule } from '@shared/common/common.module';
import { FormsModule } from '@angular/forms';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { NgxCaptchaModule } from 'ngx-captcha';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { AccountRouteGuard } from './auth/account-route-guard';
import { LanguageSwitchComponent } from './language-switch.component';
import { LoginService } from './login/login.service';
import { TenantRegistrationHelperService } from './register/tenant-registration-helper.service';
import { OAuthModule } from 'angular-oauth2-oidc';
import { PaymentHelperService } from './payment/payment-helper.service';
import { LocaleMappingService } from '@shared/locale-mapping.service';
import { PasswordModule } from 'primeng/password';
import { AppBsModalModule } from '@shared/common/appBsModal/app-bs-modal.module';
import { AccountSharedModule } from '@account/shared/account-shared.module';

export function getRecaptchaLanguage(): string {
    return new LocaleMappingService().map('recaptcha', abp.localization.currentLanguage.name);
}

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        NgxCaptchaModule,
        ModalModule.forRoot(),
        AbpZeroTemplateCommonModule,
        UtilsModule,
        ServiceProxyModule,
        AccountRoutingModule,
        OAuthModule.forRoot(),
        PasswordModule,
        AppBsModalModule,
        AccountSharedModule,
    ],
    declarations: [AccountComponent, LanguageSwitchComponent],
    providers: [LoginService, TenantRegistrationHelperService, PaymentHelperService, AccountRouteGuard],
})
export class AccountModule {}
