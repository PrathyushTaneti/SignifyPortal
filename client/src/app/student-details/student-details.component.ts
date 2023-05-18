import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CoreService } from '../services/core.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  providers: [CoreService]
})


export class StudentDetailsComponent implements OnInit {
  students: any;
  
  constructor(private http: HttpClient, private coreService: CoreService) { }

  ngOnInit(): void {
    this.coreService.getStudentDetails().subscribe(response => {
      this.students = response;
    });
    // this.http.get("https://localhost:7100/api/Admin/GetStudents").subscribe(response => {
    //   this.students = response;
    //   console.log(this.students);
    // })
  }
}
