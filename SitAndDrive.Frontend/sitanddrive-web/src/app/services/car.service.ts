import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({ providedIn: 'root' })
export class CarService {
  private readonly baseUrl = `${environment.apiUrl}/api/sitdrive/cars`;

  constructor(private http: HttpClient) {}

  getCars(page = 1, pageSize = 10): Observable<any> {
    const params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize)
      .set('includeTotal', 'true');

    return this.http.get(this.baseUrl, { params });
  }
}