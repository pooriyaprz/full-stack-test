import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(private http: HttpClient) {}

  getAllCustomers(): Observable<Customer[]> {
    const url = 'http://localhost:7259/api/customer';
    return this.http
      .get(url)
      .pipe(map((res: any) => res.map((item: any) => new Customer(item))));
  }
  getCustomer(id: string | null): Observable<Customer> {
    let url = 'http://localhost:7259/api/customer';
    url += `/${id}`;
    return this.http.get(url).pipe(map((res: any) => new Customer(res)));
  }
  createCustomer(customer: Customer): Observable<any> {
    const url = 'http://localhost:7259/api/customer';
    return this.http.post(url, customer);
  }
  editeCustomer(customer: Customer): Observable<any> {
    const url = 'http://localhost:7259/api/customer';
    return this.http.put(url, customer);
  }
}
