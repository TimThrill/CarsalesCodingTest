import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CarModel, VehicleType, BodyType } from '../models/car.model';
import { Guid } from "guid-typescript";
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VehicleTypeOptions, BodyTypeOptions } from '../models/constants';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './create-car.component.html',
  styleUrls: ['./create-car.component.css']
})
export class CreateCarComponent implements OnInit {
  public forecasts: WeatherForecast[];
  selectedCar: CarModel;
  form: FormGroup;
  vehicleTypeOptions = VehicleTypeOptions;
  bodyTypeOptions = BodyTypeOptions;

  constructor(private _carService: CarService,
    private _formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.selectedCar = {
      id: Guid.create(),
      vehicleType: VehicleType.Car,
      make: null,
      model: null,
      engine: null,
      doorCount: 0,
      wheelCount: 0,
      bodyType: BodyType.Hatchback
    };

    this.form = this._formBuilder.group({
      vehicleType: [this.selectedCar.vehicleType, Validators.required],
      make: [this.selectedCar.make, Validators.required],
      engine: [this.selectedCar.engine, Validators.required],
      doorCount: [this.selectedCar.doorCount, Validators.required],
      wheelCount: [this.selectedCar.wheelCount, Validators.required],
      bodyType: [this.selectedCar.bodyType, Validators.required]
    });
  }

  onCreateCar() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.selectedCar = this.form.value as CarModel;
    console.log("Create car: " + JSON.stringify(this.selectedCar));
    this._carService.createCar(this.selectedCar).subscribe(() => {

    });
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
