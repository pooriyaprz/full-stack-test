import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Injectable({
  providedIn: 'root',
})
export class CustomerFacade {
  constructor(private customerService: CustomerService) {}
  getCustomer(id: string | null): Observable<Customer> {
    return this.customerService.getCustomer(id);
  }
}
