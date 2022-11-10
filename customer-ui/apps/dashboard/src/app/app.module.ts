import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RouterModule } from '@angular/router';
import { appRoutes } from './app.routes';
import { CustomerListComponent } from './modules/components/customer-list/customer-list.component';
import { MaterialComponentsModule } from './modules/shared/material-components/material-components.module';
import { HttpClientModule } from '@angular/common/http';
import { CreateCustomerComponent } from './modules/components/create-customer/create-customer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NxWelcomeComponent } from './nx-welcome.component';
import { FlexLayoutModule } from '@angular/flex-layout';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselHostComponent } from './modules/components/carousel-host/carousel-host.component';

@NgModule({
  declarations: [
    CustomerListComponent,
    CreateCustomerComponent,
    AppComponent,
    NxWelcomeComponent,
    CarouselHostComponent,

  ],
  imports: [
    BrowserModule,
    MaterialComponentsModule,
    BrowserModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes, { initialNavigation: 'enabledBlocking' }),
  ],
  providers: [],
  bootstrap: [AppComponent],

})
export class AppModule {}
