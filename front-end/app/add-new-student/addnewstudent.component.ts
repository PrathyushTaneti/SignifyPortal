import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Student } from '../Models/student.model';
import { AppServiceService } from '../Services/app.service';
import { StudentService } from '../Services/student.service';

@Component({
  selector: 'app-addnewstudent',
  templateUrl: './addnewstudent.component.html',
})
  
export class AddnewstudentComponent implements OnInit {
  addNewStudentDetailsForm!: FormGroup;
  constructor(private router:Router, private service: StudentService) { }

  ngOnInit(): void {
    this.buildForm(); 
  }

  buildForm(){
    this.addNewStudentDetailsForm = new FormGroup({
      id: new FormControl(''),
      firstName: new FormControl('',[Validators.required]),
      lastName: new FormControl('',[Validators.required]),
      mobileNumber: new FormControl('',[Validators.required]),
      gender: new FormControl('',[Validators.required]),
      course: new FormControl('',[Validators.required]),
      department: new FormControl('',[Validators.required]),
      rollNumber: new FormControl('',[Validators.required]),
      guardianName: new FormControl('',[Validators.required]),
      address: new FormControl('', [Validators.required]),
      profilePicture: new FormControl('')
    })
  }

  goBack() {
    this.router.navigate(['/admin']);
  }

  addNewDetail() {
    if (this.addNewStudentDetailsForm.valid) {
      let firstName:string = this.addNewStudentDetailsForm.get('firstName')?.value;
      let lastName:string = this.addNewStudentDetailsForm.get('lastName')?.value;
      let mobileNumber:string = this.addNewStudentDetailsForm.get('mobileNumber')?.value;
      let gender:string = this.addNewStudentDetailsForm.get('gender')?.value;
      let course:string = this.addNewStudentDetailsForm.get('course')?.value;
      let department:string = this.addNewStudentDetailsForm.get('department')?.value;
      let rollNumber:string = this.addNewStudentDetailsForm.get('rollNumber')?.value;
      let guardianName:string = this.addNewStudentDetailsForm.get('guardianName')?.value;
      let address:string = this.addNewStudentDetailsForm.get('address')?.value;
      window.console.log(firstName, lastName,gender,mobileNumber,course,department,rollNumber,guardianName,address);
      // this.service.postStudentDetails({
      //   "firstName": firstName,
      //   "lastName": lastName,
      //   "mobileNumber": mobileNumber,
      //   "gender": gender,
      //   "course": course,
      //   "department": department,
      //   "rollNumber": rollNumber,
      //   "guardianName": guardianName,
      //   "address": address
      // });
      this.addNewStudentDetailsForm.get('id')?.setValue(0);
      this.addNewStudentDetailsForm.get('profilePicture')?.setValue("Downloads/propic.png");
      this.service.postStudentDetails(this.addNewStudentDetailsForm.value).subscribe();
    }
    else {
      alert("Please Enter Valid Details");
    }
  }

}
