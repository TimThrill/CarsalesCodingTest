import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { CarModel } from "../models/car.model";
import { Observable } from "rxjs";

@Injectable()
export class CarService {

  private _baseUrl: string;

  constructor(private _http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  getCars(): Observable<CarModel[]> {
    return this._http.get<CarModel[]>(`${this._baseUrl}api/car`, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }

  createCar(car: CarModel): Observable<Boolean> {
    return this._http.post<Boolean>(`${this._baseUrl}api/car`, car, {
      headers: {
        'Accept': 'application/json'
      }
    });
  }
}
