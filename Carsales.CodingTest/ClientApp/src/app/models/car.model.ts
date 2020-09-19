import { Guid } from "guid-typescript";

export interface CarModel {
  id: Guid,
  vehicleType: VehicleType,
  make: string,
  model: string,
  engine: string,
  doorCount: number,
  wheelCount: number,
  bodyType: BodyType
}

export enum VehicleType {
  Car,
  Boat,
  Bike
}

export enum BodyType {
  Hatchback,
  Sedan
}
