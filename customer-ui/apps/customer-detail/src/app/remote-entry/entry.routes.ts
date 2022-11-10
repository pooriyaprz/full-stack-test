import { Route } from '@angular/router';
import { CustomerDetailComponent } from '../components/customer-detail/customer-detail.component';
import { RemoteEntryComponent } from './entry.component';

export const remoteRoutes: Route[] = [
  { path: '', component: RemoteEntryComponent },
  { path: 'detail', component: CustomerDetailComponent },
];
