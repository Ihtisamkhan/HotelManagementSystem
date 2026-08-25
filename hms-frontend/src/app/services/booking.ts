import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  private apiUrl = environment.apiUrl + '/Booking';

  constructor(private http: HttpClient) { }

  // Customer

  createBooking(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }

  getMyBookings(): Observable<any> {
    return this.http.get(`${this.apiUrl}/my-bookings`);
  }

  getBooking(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  // Receptionist

  getPendingBookings(): Observable<any> {
    return this.http.get(`${this.apiUrl}/pending`);
  }

  acceptBooking(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/accept/${id}`, {});
  }

  rejectBooking(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/reject/${id}`, {});
  }

  getBookingHistory(): Observable<any[]> {
   return this.http.get<any[]>(`${this.apiUrl}/history`);
 }

 checkInBooking(id:number): Observable<any> {

    return this.http.put(`${this.apiUrl}/checkin/${id}`,{});

 }

 checkOutBooking(id:number): Observable<any> {

   return this.http.put(`${this.apiUrl}/checkout/${id}`,{});

 }

 getAllBookings() : Observable<any> {
   return this.http.get(`${this.apiUrl}/all`);
 }

 getBookingsByStatus(status: number): Observable<any> {

   return this.http.get(`${this.apiUrl}/status/${status}`);

 }

 getAcceptedBookings() : Observable<any> {
   return this.http.get(`${this.apiUrl}/accepted`);
 }

 getRejectedBookings() : Observable<any> {
   return this.http.get(`${this.apiUrl}/rejected`);
 }

 checkIn(id: number): Observable<any> {
   return this.http.put(`${this.apiUrl}/checkin/${id}`, {});
 }

 checkOut(id: number): Observable<any> {
   return this.http.put(`${this.apiUrl}/checkout/${id}`, {});
 }
}
