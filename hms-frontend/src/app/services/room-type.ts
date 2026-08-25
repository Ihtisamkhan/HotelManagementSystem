import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RoomTypeService {

  private apiUrl = environment.apiUrl + '/RoomType';

  constructor(private http: HttpClient) { }

  // Get All
  getAll(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  // Get By Id
  getById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  // Create
  create(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  // Update
  update(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  // Delete
  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}
