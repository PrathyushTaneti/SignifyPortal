import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class CoreService {
    private readonly apiUrl = "https://localhost:7100/api";

    constructor(private http: HttpClient) { }

    getStudentDetails() {
       return this.http.get(this.apiUrl + '/Admin/GetStudents');
    }
}