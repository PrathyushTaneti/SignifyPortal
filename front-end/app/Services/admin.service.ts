import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  public readonly signifyUrl = "https://localhost:44307/api";

  constructor(private http: HttpClient) { }

  getAllAdminDetails() {
    return this.http.get<any>(this.signifyUrl + "/AdminDetails");
  }

  getAdminDetailById(id:number) {
    return this.http.get<any>(this.signifyUrl + `/AdminDetails/id?id=${id}`);
  }

  post(data: any) {
    return this.http.post<any>(this.signifyUrl + "/AdminDetails", data);
  }

  put(id: number, data: any) {
    return this.http.put<any>(this.signifyUrl + `/AdminDetails/id?id=${id}`, data);
  }

  delete(id: number) {
    return this.http.delete<any>(this.signifyUrl + `/AdminDetails/id?id=${id}`);
  }

}
