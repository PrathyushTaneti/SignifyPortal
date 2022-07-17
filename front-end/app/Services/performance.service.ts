import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PerformanceService {
  public signifyUrl = "https://localhost:44307/api";

  constructor(private http: HttpClient) { }
  
  getPerformance(): Observable<any[]>{
    return this.http.get<any>(this.signifyUrl + '/Performance');
  }

  getPerformanceById(id: number): Observable<any[]>{
    return this.http.get<any>(this.signifyUrl + `/Performance/id?id=${id}`);
  }

  postPerformance(data: any){
    return this.http.post<any>(this.signifyUrl + '/Performance', data);
  }

  putPerformance(id: number, data: any) {
    return this.http.put<any>(this.signifyUrl + `/Performance/${id}`, data);
  }

  deletePerformance(id: number) {
    return this.http.delete<any>(this.signifyUrl + `/Performance/${id}`);
  }
}
