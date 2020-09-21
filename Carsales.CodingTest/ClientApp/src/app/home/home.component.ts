import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CarModel } from '../models/car.model';
import { MatTableDataSource } from '@angular/material/table';
import { CarService } from '../services/car.service';

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

  dataSource: MatTableDataSource<CarModel>;
  columns: string[] = ['id', 'make', 'model'];

  constructor(private _router: Router, private _carService: CarService) {
    _carService.getCars().subscribe((cars) => {
      this.dataSource = new MatTableDataSource(cars);
    });
  }

  createCar() {
    console.log("On click create car.");
    this._router.navigate(['/create-car']);
  }
}
