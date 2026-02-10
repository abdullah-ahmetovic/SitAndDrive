export interface PageResult<T> {
  items: T[];
  pageSize: number;
  currentPage: number;
  includedTotal: boolean;
  totalItems: number;
  totalPages: number;
}

export interface CarListItem {
  id: number;
  licensePlate: string;
  year: number;
  pricePerDay: number;
  transmission: CarTransmission;
  color: string;
  fuelConsumption: number;
  powerKw: number;
  manufacturerId: number;
  manufacturerName: string;
  carModelId: number;
  carModelName: string;
  branchId: number;
  branchName: string;
}

export interface CarDetails {
  id: number;
  firmId: number;
  branchId: number;
  branchName: string;
  manufacturerId: number;
  manufacturerName: string;
  carModelId: number;
  carModelName: string;
  licensePlate: string;
  vin: string;
  color: string;
  transmission: CarTransmission;
  year: number;
  powerKw: number;
  fuelConsumption: number;
  pricePerDay: number;
  status: EntityStatus;
}

export interface CreateCarRequest {
  firmId: number;
  manufacturerId: number;
  branchId: number;
  carModelId: number;
  licensePlate: string;
  vin: string;
  color: string;
  transmission: CarTransmission;
  year: number;
  powerKw: number;
  fuelConsumption: number;
  dailyPrice: number;
  status: EntityStatus;
}

export interface UpdateCarRequest {
  manufacturerId: number;
  branchId: number;
  carModelId: number;
  licensePlate: string;
  vin: string;
  color: string;
  transmission: CarTransmission;
  year: number;
  powerKw: number;
  fuelConsumption: number;
  dailyPrice: number;
  status: EntityStatus;
}

export enum CarTransmission {
  Manual = 0,
  Automatic = 1
}

export enum EntityStatus {
  Active = 0,
  Inactive = 1
}

export interface LookupItem {
  id: number;
  name: string;
}

export interface CarModelLookup {
  id: number;
  name: string;
  manufacturerId: number;
}

export interface CarFilter {
  branchId?: number | null;
  manufacturerId?: number | null;
  carModelId?: number | null;
  yearFrom?: number | null;
  yearTo?: number | null;
  priceFrom?: number | null;
  priceTo?: number | null;
}
