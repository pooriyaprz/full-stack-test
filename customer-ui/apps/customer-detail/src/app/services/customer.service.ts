import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(private http: HttpClient) {}

  getCustomer(id: string | null): Observable<Customer> {
    let url = 'http://localhost:7259/api/customer';
    url += `/${id}`;
    return this.http.get(url).pipe(map((res: any) => new Customer(res)));
  }
}
