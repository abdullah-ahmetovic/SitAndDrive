import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { LookupItem, CarModelLookup } from '../models/car.model';

@Injectable({ providedIn: 'root' })
export class LookupService {
  private readonly baseUrl = `${environment.apiUrl}/api/sitdrive/lookups`;

  constructor(private http: HttpClient) {}

  getBranches(): Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.baseUrl}/branches`);
  }

  getManufacturers(): Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.baseUrl}/manufacturers`);
  }

  getCarModels(manufacturerId?: number): Observable<CarModelLookup[]> {
    let params = new HttpParams();
    if (manufacturerId) {
      params = params.set('manufacturerId', manufacturerId);
    }
    return this.http.get<CarModelLookup[]>(`${this.baseUrl}/car-models`, { params });
  }
}
