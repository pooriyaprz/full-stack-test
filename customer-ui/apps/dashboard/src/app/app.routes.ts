import { CustomerResolver } from './modules/resolver/customer.resolver';
import { CustomerListComponent } from './modules/components/customer-list/customer-list.component';

import { Route } from '@angular/router';
import { CreateCustomerComponent } from './modules/components/create-customer/create-customer.component';
import { CustomerEditeResolver } from './modules/resolver/customer-edite.resolver';
import { loadRemoteModule } from '@nrwl/angular/mf';
export const appRoutes: Route[] = [
  {
    path: 'customer-detail',
    loadChildren: () =>
      loadRemoteModule('customer-detail', './Module').then(
        (m) => m.RemoteEntryModule
      ),
  },

  {
    path: '',
    component: CustomerListComponent,
    resolve: { data: CustomerResolver },
  },
  {
    path: 'create',
    component: CreateCustomerComponent,
  },
  {
    path: 'edite/:id',
    component: CreateCustomerComponent,
    resolve: { data: CustomerEditeResolver },
  },
];
