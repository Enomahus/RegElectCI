import {
  ApplicationConfig,
  LOCALE_ID,
  provideBrowserGlobalErrorListeners,
  provideZoneChangeDetection,
} from '@angular/core';
import {
  provideRouter,
  TitleStrategy,
  withComponentInputBinding,
} from '@angular/router';

import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideTranslateService } from '@ngx-translate/core';
import { provideTranslateHttpLoader } from '@ngx-translate/http-loader';
import { provideToastr } from 'ngx-toastr';
import { routes } from './app.routes';
import { CustomTitleStrategy } from './core/title/custom-title-strategy';
import { langInterceptor } from './services/api/interceptors/lang-interceptor';
import { ConfigService } from './services/config.service';
import { APP_BASE_URL } from './services/nswag/api-nswag-client';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideHttpClient(withInterceptors([langInterceptor])),
    provideRouter(routes, withComponentInputBinding()),
    {
      provide: APP_BASE_URL,
      useFactory: (configService: ConfigService) =>
        configService.getConfig().apiUrl,
      deps: [ConfigService],
    },
    //provideTranslations(),
    provideTranslateService({
      lang: 'en',
      fallbackLang: 'en',
      loader: provideTranslateHttpLoader({
        prefix: '/i18n/',
        suffix: '.json',
      }),
    }),
    provideToastr(),
    { provide: LOCALE_ID, useValue: 'fr-FR' },
    {
      provide: TitleStrategy,
      useClass: CustomTitleStrategy,
    },
  ],
};
