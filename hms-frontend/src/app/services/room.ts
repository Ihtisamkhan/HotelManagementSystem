import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private apiUrl = environment.apiUrl + '/Room';

  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {

  console.log("Calling:", this.apiUrl);

  return this.http.get(this.apiUrl);

}

  getById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  getAvailableRooms(): Observable<any> {
    return this.http.get(`${this.apiUrl}/available`);
  }

  getRoomsByType(roomTypeId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/roomtype/${roomTypeId}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  update(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getRooms(): Observable<any> {
   return this.http.get(environment.apiUrl + '/Room');
 }

 getRoomsByStatus(status:number) : Observable<any> {
    return this.http.get(`${environment.apiUrl}/Room/status/${status}`);
 }

}
