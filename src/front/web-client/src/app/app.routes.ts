import { Routes } from '@angular/router';
import { Dashboard } from './pages/dashboard/dashboard';
import { Login } from './pages/login/login';
import { PageTemplate } from './shared/page-template/page-template';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: Login,
    title: 'login.title',
  },
  {
    path: '',
    component: PageTemplate,
    children: [
      {
        path: 'dashboard',
        component: Dashboard,
        title: 'global.home',
      },
    ],
  },
];
