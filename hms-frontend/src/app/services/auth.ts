import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

private apiUrl = environment.apiUrl + '/Auth';

  constructor(private http: HttpClient) { }

  
  // LOGIN STATUS
  

  private loggedIn = new BehaviorSubject<boolean>(this.hasToken());

  loggedIn$ = this.loggedIn.asObservable();

  private hasToken(): boolean {
    return localStorage.getItem('token') != null;
  }

  
  // CUSTOMER
  

  registerCustomer(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register-customer`, data);
  }

  login(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, data);
  }

  saveUser(response:any) {

  localStorage.setItem("token", response.token);

  localStorage.setItem("username", response.username);

  localStorage.setItem("role", response.role);

  this.loggedIn.next(true);

}

  // Logout

  logout() {

    localStorage.clear();

    this.loggedIn.next(false);

  }

  registerOwner(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register-owner`, data);
  }

  createEmployee(data: any): Observable<any> {

    return this.http.post(
      `${this.apiUrl}/create-employee`,
      data,
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem('token')}`
        }
      }
    );

  }

  getUsersByRole(role: string): Observable<any> {

    return this.http.get(environment.apiUrl + '/Auth/users/' + role);

  }

}