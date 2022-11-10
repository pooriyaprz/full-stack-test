import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private userId$: BehaviorSubject<string> = new BehaviorSubject<string>('');

  userId = this.userId$.asObservable();
  private sidenav!: MatSidenav;
  getUserId(id: string) {
    console.log(id);
    this.userId$.next(id);
  }

  public setSidenav(sidenav: MatSidenav) {
    this.sidenav = sidenav;
  }

  public open() {
    return this.sidenav.open();
  }

  public close() {
    return this.sidenav.close();
  }

  public toggle(): void {
    this.sidenav.toggle();
    // this.getUserId(id);
  }
}
