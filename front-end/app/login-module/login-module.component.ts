import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppServiceService } from '../Services/app.service';
import * as AOS from 'aos';
import { Student } from '../Models/student.model';
import { Teacher } from '../Models/teacher.model';
import { StudentService } from '../Services/student.service';
import { Observable, tap } from 'rxjs';
import { async } from '@angular/core/testing';
import { TeacherService } from '../Services/employee.service';
import { AdminService } from '../Services/admin.service';
import { AdminDetails } from '../Models/admin-details.model';
import { AttendanceTrackerService } from '../Services/attendance-tracker.service';

@Component({
  selector: 'app-login-module',
  templateUrl: './login-module.component.html',
})
export class LoginModuleComponent implements OnInit {
  loginDetailsForm!: FormGroup;
  showAlert: boolean = false;
  isAdmin: boolean = false;
  isStudent: boolean = false;
  isTeacher: boolean = false;
  adminDetails!: AdminDetails[];
  studentDetails!: Student[];
  teacherDetails!: Teacher[]; 

  constructor(private router: Router, private appService: AppServiceService, private studentService: StudentService, private employeeService: TeacherService, private adminService: AdminService,
  private attendanceTracker : AttendanceTrackerService) { }

  ngOnInit(): void {
    this.buildForm();
    AOS.init({
      offset: 80,
      duration: 2500,
      mirror: true,
      once: false,
    });
  }

  buildForm() {
    this.loginDetailsForm = new FormGroup({
      id: new FormControl(''),
      emailAddress: new FormControl('',[Validators.required]),
      password: new FormControl('',[Validators.required])
    });
  }

  goToHomePage() {
    this.router.navigate(['']);
  }

  login() {
    if (this.loginDetailsForm.valid) {
      this.checkStudent();
      this.checkEmployee();
      this.checkAdmin();
    }
    this.showErrorMessages();
  }

  checkEmployee():void {
    this.employeeService.getEmployeeList().subscribe(data => {
      this.teacherDetails = data;
      if (this.teacherDetails.find(detail => detail.emailAddress == this.loginDetailsForm.get('emailAddress')!.value)) {
        this.attendanceTracker.post({
          date: "2022-06-22",
          identity: this.loginDetailsForm.get('emailAddress')!.value,
          designation: "teacher"
        }).subscribe();
        this.router.navigate(['teacher']);
      }
    })
  }
  
  checkAdmin(): void{
    this.adminService.getAllAdminDetails().subscribe(data => {
      this.adminDetails = data;
      if (this.adminDetails.find(details => details.emailAddress == this.loginDetailsForm.get('emailAddress')!.value)) {
        this.isAdmin = true;
        this.router.navigate(['admin']);
      }
   })
  }

  checkStudent(): void{
    this.studentService.getStudentList().subscribe(data => {
      this.studentDetails = data;
      const student = this.studentDetails.find(student => student.rollNumber  == this.loginDetailsForm.get('emailAddress')?.value);
      if (student != null) {
        this.isStudent = true;
        this.attendanceTracker.post({
          date: "2022-06-22",
          identity: this.loginDetailsForm.get('emailAddress')!.value,
          designation: "student"
        }).subscribe();
        this.router.navigate(['student/'+student.id]);
      }
    });
  }

  checkTeacher(): boolean{
    return this.isTeacher;
  }

  showErrorMessages() {
    this.loginDetailsForm.markAllAsTouched();
  }

  get emailAddress() {
    return this.loginDetailsForm.get('emailAddress');
  }

  get password() {
    return this.loginDetailsForm.get('password');
  }
}
