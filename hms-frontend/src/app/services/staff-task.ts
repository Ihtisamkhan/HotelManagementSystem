import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StaffTaskService {

  private apiUrl = environment.apiUrl + '/StaffTask';

  constructor(private http: HttpClient) { }

  createTask(data:any):Observable<any>{
    return this.http.post(this.apiUrl,data);
  }

  getStaff(): Observable<any> {
    return this.http.get(environment.apiUrl + '/Auth/staff');
  }

  getAllTasks():Observable<any>{
    return this.http.get(this.apiUrl);
  }

  updateTask(id:number,data:any):Observable<any>{
    return this.http.put(`${this.apiUrl}/${id}`,data);
  }

  deleteTask(id:number):Observable<any>{
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getMyTasks():Observable<any>{
    return this.http.get(`${this.apiUrl}/my-tasks`);
  }

  completeTask(id:number):Observable<any>{
    return this.http.put(`${this.apiUrl}/complete/${id}`,{});
  }

  getCompletedTasks() :Observable<any>{
   return this.http.get(`${this.apiUrl}/completed`);
 }

  getTaskStatus() :Observable<any> {

   return this.http.get<any[]>(`${this.apiUrl}/task-status`);
 }



}
