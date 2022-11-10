import { CustomerFacade } from './../facade/customer.facade';
import { Customer } from './../models/customer.model';
import { Resolve } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CustomerResolver implements Resolve<Customer[]> {
  constructor(private customerFacade: CustomerFacade) {}
  resolve(): Observable<Customer[]> {
    return this.customerFacade.getAllCustomers();
  }
}
