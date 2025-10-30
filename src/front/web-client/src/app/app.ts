import { AsyncPipe } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Subject } from 'rxjs';
import { Loader } from './shared/loader/loader';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AsyncPipe, Loader],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App implements OnInit {
  protected readonly title = signal('web-client');
  translationLoaded$ = new Subject<boolean>();

  constructor(private translateService: TranslateService) {
    translateService.addLangs(['fr']);
    translateService.setFallbackLang('fr');
    //this.translationLoaded$ = translateService.use('fr');
  }

  ngOnInit(): void {
    this.translateService.use('fr').subscribe(() => {
      this.translationLoaded$.next(true);
    });
  }
}
