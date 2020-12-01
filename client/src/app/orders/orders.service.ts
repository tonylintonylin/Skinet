import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getOrdersForUser(): Observable<any> {
    return this.http.get(this.baseUrl + 'orders');
  }

  getOrderDetailed(id: number): Observable<any> {
    return this.http.get(this.baseUrl + 'orders/' + id);
  }
}
