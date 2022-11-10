import { CustomerFacade } from './../../facade/customer.facade';
import { distinctUntilChanged, Observable } from 'rxjs';
import { Component, OnInit, ViewChild } from '@angular/core';

import { UserService } from '@customer-ui/shared/data-access-user';

import { Customer } from '../../models/customer.model';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css'],
})
export class CustomerDetailComponent implements OnInit {
  userId: any;
  customer!: Customer;
  showFiller = false;
  constructor(
    private userService: UserService,
    private customerFacade: CustomerFacade
  ) {}

  ngOnInit() {
    this.userService.userId
      .pipe(distinctUntilChanged())
      .subscribe(async (userId: any) => {
        this.userId = userId;
      });
    this.customerFacade.getCustomer(this.userId).subscribe((x) => {
      this.customer = x;
    });
  }

}
