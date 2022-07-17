import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ActiveProgramsService {
  public readonly signifyApiUrl = "https://localhost:44307/api";

  constructor(private http: HttpClient) { }
  
  getAllActivePrograms() {
    return this.http.get<any>(this.signifyApiUrl + '/ActivePrograms');
  }

  getActiveProgramById(id:number) {
    return this.http.get<any>(this.signifyApiUrl + `/ActivePrograms/${id}`);
  }

  createProgram(data: any) {
    return this.http.post<any>(this.signifyApiUrl + '/ActivePrograms', data);
  }

  deleteProgram(id: number) {
    return this.http.delete<any>(this.signifyApiUrl + `/ActivePrograms?id=${id}`)    
  }
}
