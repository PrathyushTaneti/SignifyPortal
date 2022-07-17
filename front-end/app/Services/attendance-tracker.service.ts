import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AttendanceTrackerService {

  public readonly signifyApiUrl = "https://localhost:44307/api";

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get<any>(this.signifyApiUrl + "/AttendanceTracker");
  }

  post(data:any) {
    return this.http.post<any>(this.signifyApiUrl + "/AttendanceTracker", data);
  }
}
