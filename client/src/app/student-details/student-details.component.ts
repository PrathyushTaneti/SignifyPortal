import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  students: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get("https://localhost:7100/api/Admin/GetStudents").subscribe(response => {
      this.students = response;
      console.log(this.students);
    })
  }
}
