import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // privremeni "ping" da vidimo da radi
  pingSwagger(): Observable<any> {
    return this.http.get(`${this.baseUrl}/swagger/index.html`, { responseType: 'text' as any });
  }

  // Cars - za sad samo basic list, kasnije dodamo filter/paging parametre
  getCars(params?: Record<string, any>): Observable<any> {
    let httpParams = new HttpParams();
    if (params) {
      Object.keys(params).forEach(k => {
        const v = params[k];
        if (v !== null && v !== undefined && v !== '') {
          httpParams = httpParams.set(k, v);
        }
      });
    }
    return this.http.get(`${this.baseUrl}/api/sitdrive/cars`, { params: httpParams });
  }
}