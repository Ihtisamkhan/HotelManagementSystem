import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private apiUrl = environment.apiUrl + '/Dashboard';

  constructor(private http: HttpClient) { }

  getOwnerDashboard(): Observable<any> {

    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    return this.http.get(`${this.apiUrl}/owner`, { headers });

  }

  getRoomStatistics() : Observable<any> {
    return this.http.get(environment.apiUrl + '/Dashboard/room-statistics');
 }

}
