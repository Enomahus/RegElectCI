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
import { provideToastr } from 'ngx-toastr';
import { routes } from './app.routes';
import { provideTranslations } from './config/provideTranslations';
import { CustomTitleStrategy } from './core/title/custom-title-strategy';
import { langInterceptor } from './services/api/interceptors/lang-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideHttpClient(withInterceptors([langInterceptor])),
    provideRouter(routes, withComponentInputBinding()),
    provideTranslations(),
    provideToastr(),
    { provide: LOCALE_ID, useValue: 'fr-FR' },
    {
      provide: TitleStrategy,
      useClass: CustomTitleStrategy,
    },
  ],
};
