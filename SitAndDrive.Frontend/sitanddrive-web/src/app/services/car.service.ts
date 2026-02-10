import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import {
  CarListItem,
  CarDetails,
  CreateCarRequest,
  UpdateCarRequest,
  PageResult,
  CarFilter
} from '../models/car.model';

@Injectable({ providedIn: 'root' })
export class CarService {
  private readonly baseUrl = `${environment.apiUrl}/api/sitdrive/cars`;

  constructor(private http: HttpClient) {}

  getCars(page = 1, pageSize = 10, filter?: CarFilter): Observable<PageResult<CarListItem>> {
    let params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize)
      .set('includeTotal', 'true');

    if (filter) {
      if (filter.branchId) params = params.set('branchId', filter.branchId);
      if (filter.manufacturerId) params = params.set('manufacturerId', filter.manufacturerId);
      if (filter.carModelId) params = params.set('carModelId', filter.carModelId);
      if (filter.yearFrom) params = params.set('yearFrom', filter.yearFrom);
      if (filter.yearTo) params = params.set('yearTo', filter.yearTo);
      if (filter.priceFrom) params = params.set('priceFrom', filter.priceFrom);
      if (filter.priceTo) params = params.set('priceTo', filter.priceTo);
    }

    return this.http.get<PageResult<CarListItem>>(this.baseUrl, { params });
  }

  getCarById(id: number): Observable<CarDetails> {
    return this.http.get<CarDetails>(`${this.baseUrl}/${id}`);
  }

  createCar(request: CreateCarRequest): Observable<number> {
    return this.http.post<number>(this.baseUrl, request);
  }

  updateCar(id: number, request: UpdateCarRequest): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, request);
  }

  deleteCar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
