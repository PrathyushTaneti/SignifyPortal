import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActiveMeetingsService {

  public readonly signifyApiUrl = "https://localhost:44307/api";

  constructor(private http: HttpClient) { }
  
  getActiveMeetingsList(): Observable<any[]>{
    return this.http.get<any>(this.signifyApiUrl + '/ActiveMeetings');
  }

  getMeetingById(id: number) {
    return this.http.get<any>(this.signifyApiUrl + `/ActiveMeetings/${id}`);
  }

  postMeeting(data: any) {
    return this.http.post<any>(this.signifyApiUrl + '/ActiveMeetings', data);
  }

  putMeeting(id: number,data:any) {
    return this.http.put<any>(this.signifyApiUrl + `/ActiveMeetings/${id}`, data);
  }

  deleteMeeting(id: number) {
    return this.http.delete<any>(this.signifyApiUrl + `/ActiveMeetings/id?id=${id}`);
  }
}
