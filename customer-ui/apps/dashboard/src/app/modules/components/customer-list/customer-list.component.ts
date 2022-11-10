import { CustomerDetailComponent } from './../../../../../../customer-detail/src/app/components/customer-detail/customer-detail.component';
import { Customer } from './../../models/customer.model';
import {
  Component,
  CUSTOM_ELEMENTS_SCHEMA,
  Inject,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MatTable } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '@customer-ui/shared/data-access-user';
import { MatSidenav } from '@angular/material/sidenav';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss'],
})
export class CustomerListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'actions'];
  dataSource = [];

  @ViewChild(MatTable)
  table!: MatTable<Customer[]>;
  @ViewChild('rightSidenav') public sidenav!: MatSidenav;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private matDialog: MatDialog
  ) {}
  ngOnInit(): void {
    this.dataSource = this.route.snapshot.data['data'];
  }
  createCustomer() {
    this.router.navigate(['create']);
  }
  editeCustomer(id: string) {
    this.router.navigate(['edite/' + id]);
  }
  customerDetail(id: string) {
    this.userService.getUserId(id);
    this.matDialog.open(CustomerDetailComponent, {
      minWidth: '220px',
    });
  }
}
