import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RouterStateSnapshot, TitleStrategy } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin, switchMap, take } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomTitleStrategy extends TitleStrategy {
  constructor(
    private readonly title: Title,
    private readonly translateService: TranslateService,
  ) {
    super();
  }

  override updateTitle(snapshot: RouterStateSnapshot): void {
    const routeTitleKey = this.buildTitle(snapshot);

    // S'assurer que la langue est bien définie
    const currentLang =
      this.translateService.getCurrentLang() ||
      this.translateService.getFallbackLang();
    if (!currentLang) {
      console.warn('Langue non définie pour ngx-translate');
      return;
    }

    const projectTitle$ = this.translateService
      .get('global.projectTitle')
      .pipe(take(1));

    if (routeTitleKey) {
      const routeTitle$ = this.translateService
        .get(routeTitleKey)
        .pipe(take(1));
      forkJoin([projectTitle$, routeTitle$])
        .pipe(
          switchMap(([projectTitle, translateTitle]) =>
            this.translateService.get('global.titleTemplate', {
              title: translateTitle,
              project: projectTitle,
            }),
          ),
          take(1),
        )
        .subscribe((finalTitle) => this.title.setTitle(finalTitle));
    } else {
      projectTitle$
        .pipe(
          switchMap((projectTitle) =>
            this.translateService.get('global.noTitleTemplate', {
              project: projectTitle,
            }),
          ),
          take(1),
        )
        .subscribe((fallbackTitle) => this.title.setTitle(fallbackTitle));
    }
  }
}
