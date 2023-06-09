import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  providers: [JwtHelperService]
})

export class NavbarComponent {
  public title = 'Signify';
  public logo = "../assets/images/SIGNIFY-2.png"

  loginDetailsForm!: FormGroup;
  showAlert: boolean = false;
  isAdmin: boolean = false;
  isStudent: boolean = false;
  isTeacher: boolean = false;
  invalidLogin!: boolean;
  user: string = "";
  pass: string = "";
  // adminDetails!: AdminDetails[];
  // studentDetails!: Student[];
  // teacherDetails!: Teacher[];

  constructor(private fb: FormBuilder, private router: Router, private http: HttpClient) { }

  // constructor(private router: Router, private appService: AppServiceService, private studentService: StudentService, private employeeService: TeacherService, private adminService: AdminService,
  //   private attendanceTracker: AttendanceTrackerService) { }

  ngOnInit(): void {
    this.buildForm();
    // AOS.init({
    //   offset: 80,
    //   duration: 2500,
    //   mirror: true,
    //   once: false,
    // });
  }

  buildForm() {
    this.loginDetailsForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      userName: new FormControl('',
        [Validators.required, Validators.maxLength(15)]),
      password: new FormControl('',
        [Validators.required, Validators.maxLength(15)]),
      hobbies: new FormArray([])
    });
  }

  goToHomePage() {
    this.router.navigate(['']);
  }

  login() {
    if (this.loginDetailsForm.valid) {
      let userName = this.loginDetailsForm.get("userName")?.value;
      let password = this.loginDetailsForm.get("password")?.value;
      window.console.log(userName, password);
      const credentials = {
        'userName': userName,
        'password': password
      };
      this.http.post("https://localhost:7100/api/Login/Login", credentials).subscribe(
        response => {
          const token = (<any>response).token;
          localStorage.setItem("jwt", token);
          this.invalidLogin = false;
          this.router.navigate(['/admin']);
        }, err => {
          this.invalidLogin = true;
        }
      );
    }
  }

  // checkEmployee(): void {
  //   this.employeeService.getEmployeeList().subscribe(data => {
  //     this.teacherDetails = data;
  //     if (this.teacherDetails.find(detail => detail.emailAddress == this.loginDetailsForm.get('emailAddress')!.value)) {
  //       this.attendanceTracker.post({
  //         date: "2022-06-22",
  //         identity: this.loginDetailsForm.get('emailAddress')!.value,
  //         designation: "teacher"
  //       }).subscribe();
  //       this.router.navigate(['teacher']);
  //     }
  //   })
  // }

  // checkAdmin(): void {
  //   this.adminService.getAllAdminDetails().subscribe(data => {
  //     this.adminDetails = data;
  //     if (this.adminDetails.find(details => details.emailAddress == this.loginDetailsForm.get('emailAddress')!.value)) {
  //       this.isAdmin = true;
  //       this.router.navigate(['admin']);
  //     }
  //   })
  // }

  checkStudent(): void {
    // this.studentService.getStudentList().subscribe(data => {
    //   this.studentDetails = data;
    //   const student = this.studentDetails.find(student => student.rollNumber == this.loginDetailsForm.get('emailAddress')?.value);
    //   if (student != null) {
    //     this.isStudent = true;
    //     this.attendanceTracker.post({
    //       date: "2022-06-22",
    //       identity: this.loginDetailsForm.get('emailAddress')!.value,
    //       designation: "student"
    //     }).subscribe();
    //     this.router.navigate(['student/' + student.id]);
    //   }
    // });
  }

  checkTeacher(): boolean {
    return this.isTeacher;
  }

  showErrorMessages() {
    this.loginDetailsForm.markAllAsTouched();
  }

  get userName() {
    return this.loginDetailsForm.get('userName');
  }

  get password() {
    return this.loginDetailsForm.get('password');
  }

  signUp(form: NgForm) {
    var credentials = {

    }
  }

}

