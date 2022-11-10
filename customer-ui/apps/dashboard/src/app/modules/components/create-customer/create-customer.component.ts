import { CustomerFacade } from './../../facade/customer.facade';
import { Customer } from './../../models/customer.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
} from '@angular/material/snack-bar';

@Component({
  selector: 'app-create-customer',
  templateUrl: './create-customer.component.html',
  styleUrls: ['./create-customer.component.scss'],
})
export class CreateCustomerComponent implements OnInit {
  form!: FormGroup;
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  constructor(
    private fb: FormBuilder,
    private customerFacade: CustomerFacade,
    private route: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private router: Router
  ) {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required]],
    });
  }
  customerDetail: Customer | null = null;
  ngOnInit() {
    this.customerDetail = this.route.snapshot.data['data'];
    if (this.customerDetail) {
      this.form.patchValue(this.customerDetail);
    }
  }

  create(form: FormGroup) {
    if (form.invalid) {
      return;
    }
    const values = this.form.value;
    const params: Customer = {
      name: values.name,
      email: values.email,
    };
    this.customerFacade.createCustomer(params).subscribe({
      next: (result) => {
        this._snackBar.open('success', '', {
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
          duration: 1000,
        });
        this.router.navigate([''], { relativeTo: this.route });
      },
      error: (error) => {
        //in case of using api can pass the api errors
        this._snackBar.open(error ? error.message : 'failed', '', {
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
          duration: 1000,
        });
      },
    });
  }
  edite(form: FormGroup) {
    if (form.invalid) {
      return;
    }
    const values = this.form.value;
    const params: Customer = {
      name: values.name,
      email: values.email,
      id: this.customerDetail?.id,
    };
    this.customerFacade.editeCustomer(params).subscribe({
      next: (result) => {
        this._snackBar.open('success', '', {
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
          duration: 1000,
        });
        this.router.navigate([''], { relativeTo: this.route });
      },
      error: (error) => {
        console.log(error)
        //in case of using api can pass the api errors
        this._snackBar.open(error ? error.message : 'failed', '', {
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
          duration: 1000,
        });
      },
    });
  }
}
