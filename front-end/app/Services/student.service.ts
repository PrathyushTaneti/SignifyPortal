import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Student } from '../Models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  public readonly signifyApiUrl = "https://localhost:44307/api";

  constructor(private http: HttpClient) { }

  getStudentList(): Observable<any[]>{
    return this.http.get<any>(this.signifyApiUrl + '/StudentDetail');
  }

  getStudentDetailById(id: number) {
    return this.http.get<any>(this.signifyApiUrl + `/StudentDetail/id?id=${id}`);
  }

  postStudentDetails(data: any) {
    return this.http.post<any>(this.signifyApiUrl + '/StudentDetail', data);
  }

  putStudentDetails(id: number,data:any) {
    return this.http.put<any>(this.signifyApiUrl + `/StudentDetail/${id}`, data);
  }

  deleteStudentDetails(id: number) {
    return this.http.delete<any>(this.signifyApiUrl + `/StudentDetail/id?id=${id}`);
  }
}
