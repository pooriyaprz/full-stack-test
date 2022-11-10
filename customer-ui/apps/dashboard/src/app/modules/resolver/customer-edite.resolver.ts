import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { CustomerFacade } from '../facade/customer.facade';
import { Customer } from '../models/customer.model';
@Injectable({ providedIn: 'root' })
export class CustomerEditeResolver implements Resolve<Customer> {
  constructor(private customerFacade: CustomerFacade) {}
  resolve(route: ActivatedRouteSnapshot): Observable<Customer> {
    return this.customerFacade.getCustomer(route.paramMap.get('id'));
  }
}
