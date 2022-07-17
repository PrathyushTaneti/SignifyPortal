import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  public readonly signifyApiUrl = "https://localhost:44307/api";

  constructor(private http: HttpClient) { }
  
  ngOnInit() { }

  getEmployeeList(): Observable<any[]>{
    return this.http.get<any>(this.signifyApiUrl + '/EmployeeDetail');
  }

  getEmployeeById(id: number) {
    return this.http.get<any>(this.signifyApiUrl + `/EmployeeDetail/${id}`);
  }

  postEmployeeDetails(data: any) {
    return this.http.post<any>(this.signifyApiUrl + '/EmployeeDetail', data);
  }

  putEmployeeDetails(id: number,data:any) {
    return this.http.put<any>(this.signifyApiUrl + `/EmployeeDetail/${id}`, data);
  }

  deleteEmployeeDetails(id: number) {
    return this.http.delete<any>(this.signifyApiUrl + `/EmployeeDetail/id?id=${id}`);
  }

}

