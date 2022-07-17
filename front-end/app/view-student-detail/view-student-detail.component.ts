import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from '../Models/student.model';
import { StudentService } from '../Services/student.service';

@Component({
  selector: 'app-view-student-detail',
  templateUrl: './view-student-detail.component.html',
})
export class ViewStudentDetailComponent implements OnInit {
  public id!: number;
  public studentDetail!: Student;
  public isStudentPresent: boolean = false;

  constructor(private router: Router, private activeRouter: ActivatedRoute,private  studentService: StudentService) { }

  ngOnInit(): void {
    this.activeRouter.paramMap.subscribe((parameter) => {
      this.id = parameter.get('id') as any as number;
      this.assignStudentDetail(this.id);
    })
  }

  assignStudentDetail(id: number) {
    window.console.log(id);
    this.studentService.getStudentDetailById(id).subscribe(student => {
      this.studentDetail = student;
      window.console.log(this.studentDetail);
      this.isStudentPresent = true;
    })
  }

   editStudentDetail(id: number) {
    this.studentService.getStudentDetailById(id).subscribe(student => {
      this.studentDetail = student;
    })
    window.console.log(this.studentDetail);
   }
  
  deleteStudentContact(id: any) {
    window.console.log("Delete",id);
    this.studentService.deleteStudentDetails(id).subscribe();
    this.router.navigate(['admin/studentdetails']);  
  }
}
