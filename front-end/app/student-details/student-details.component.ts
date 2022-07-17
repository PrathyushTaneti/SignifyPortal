import { Component, OnInit } from '@angular/core';
import { async } from '@angular/core/testing';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AppServiceService } from '../Services/app.service';
import { StudentService } from '../Services/student.service';
import { Student } from '../Models/student.model';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
})
  
export class StudentDetailsComponent implements OnInit {
  allStudentDetails!: Observable<any[]>;
  studentDetail!: Student;

  constructor(private service : StudentService, private router : Router) { }

  ngOnInit(): void {
    this.allStudentDetails = this.service.getStudentList();
  }

  addNewStudent() {
    this.router.navigate(['admin/addnewstudent']);
  }

  seletedStudent(id: number,name:string) {
    //window.console.log(id, name);
    this.router.navigate(['/admin/viewstudentdetail',id]);
  }
}
