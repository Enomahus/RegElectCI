import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Footer } from './footer/footer';

@Component({
  selector: 'app-page-template',
  imports: [RouterOutlet, Footer],
  templateUrl: './page-template.html',
  styleUrl: './page-template.scss',
})
export class PageTemplate {}
