import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';
@Injectable({
  providedIn: 'root',
})
export class CustomerFacade {
  constructor(private customerService: CustomerService) {}

  getAllCustomers(): Observable<Customer[]> {
    return this.customerService.getAllCustomers();
  }
  getCustomer(id: string | null): Observable<Customer> {
    return this.customerService.getCustomer(id);
  }
  createCustomer(customer: Customer): Observable<any> {
    return this.customerService.createCustomer(customer);
  }
  editeCustomer(customer: Customer): Observable<any> {
    return this.customerService.editeCustomer(customer);
  }
}
