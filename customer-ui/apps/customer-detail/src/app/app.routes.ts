import { Route } from '@angular/router';
import { CustomerDetailComponent } from './components/customer-detail/customer-detail.component';

export const appRoutes: Route[] = [
  {
    path: '',
    loadChildren: () =>
      import('./remote-entry/entry.module').then((m) => m.RemoteEntryModule),
  },
  {
    path: 'detail',
    component: CustomerDetailComponent,
  },
];
