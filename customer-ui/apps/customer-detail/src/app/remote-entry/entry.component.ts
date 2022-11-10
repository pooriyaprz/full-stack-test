import { Component } from '@angular/core';

import { distinctUntilChanged } from 'rxjs';

@Component({
  selector: 'customer-ui-customer-detail-entry',
  template: `<div>test</div>`,
})
export class RemoteEntryComponent {
  test: string | undefined;
  constructor() {}
}
