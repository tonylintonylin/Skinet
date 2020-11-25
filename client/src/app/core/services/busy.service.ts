import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root',
})
export class BusyService {
  busyRequestcount = 0;

  constructor(private spinnerService: NgxSpinnerService) {}

  busy(): void {
    this.busyRequestcount++;
    this.spinnerService.show(undefined, {
      type: 'timer',
      bdColor: 'rgba(255,255,255,0.7)',
      color: '#333333',
    });
  }

  idle(): void {
    this.busyRequestcount--;
    if (this.busyRequestcount <= 0) {
      this.busyRequestcount = 0;
      this.spinnerService.hide();
    }
  }
}
