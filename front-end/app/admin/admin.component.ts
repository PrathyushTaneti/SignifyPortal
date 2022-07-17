import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppServiceService } from '../Services/app.service';
import { FormControl, FormGroup ,Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { slideInAnimation } from '../app.animation';
import { StudentService } from '../Services/student.service';
import { TeacherComponent } from '../teacher/teacher.component';
import { TeacherService } from '../Services/employee.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  animations : [slideInAnimation]
})
  
export class AdminComponent implements OnInit {
  allEmployeeDetails!: Observable<any[]>;
  allStudentDetails!: Observable<any[]>;
  studentAttendance: string[] = [];
  constructor(private studentService: StudentService, private router: Router, private employeeService : TeacherService) { }

  ngOnInit(): void {
    this.allEmployeeDetails = this.employeeService.getEmployeeList();
    this.allStudentDetails = this.studentService.getStudentList();
    
    this.allEmployeeDetails.forEach(element => {
      window.console.log(element);
    })
    this.allStudentDetails.forEach(element => {
      window.console.log(element);
    })
  }
}
