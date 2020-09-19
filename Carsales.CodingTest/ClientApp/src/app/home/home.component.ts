import { Component } from '@angular/core';
import { Router } from '@angular/router';

interface CarDropdownOption {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  carOptions: CarDropdownOption[] = [
    { value: '0', viewValue: 'Create Car' }
  ];

  constructor(private _router: Router) {}

  createCar() {
    console.log("On click create car.");
    this._router.navigate(['/create-car']);
  }
}
