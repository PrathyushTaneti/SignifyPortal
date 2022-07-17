import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ActiveMeetings } from '../Models/activeMeetings.model';
import { ActivePrograms } from '../Models/activeProgram.model';
import { ClassDetails } from '../Models/classDetails.model';
import { Student } from '../Models/student.model';
import { ActiveMeetingsService } from '../Services/active-meetings.service';
import { ActiveProgramsService } from '../Services/active-programs.service';
import { AppServiceService } from '../Services/app.service';
import { StudentService } from '../Services/student.service';
import { PerformanceService } from '../Services/performance.service';
import { Performance } from '../Models/performance.model';



@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
})
export class StudentComponent implements OnInit {
  activeMeetings!: ActiveMeetings[];
  activePrograms!: ActivePrograms[];
  public id!: number;
  public studentDetail!: Student;
  public rollNumber!: string;
  performanceList!: Performance[];
  individialPerformance!: Performance[];
  showPerformanceList: boolean = false;

  constructor(private service : AppServiceService, private meetingsService : ActiveMeetingsService, private router :  Router, private programService : ActiveProgramsService, private activeRouter : ActivatedRoute, private studentService : StudentService, private performanceService: PerformanceService) { }

  ngOnInit(): void {
    this.meetingsService.getActiveMeetingsList().subscribe(data => {
      this.activeMeetings = data;
      window.console.log("sss", this.activeMeetings);
    });
    this.programService.getAllActivePrograms().subscribe(data => {
      this.activePrograms = data;
      window.console.log("sss", this.activePrograms);
    });
    this.activeRouter.paramMap.subscribe((parameter) => {
      this.id = parameter.get('id') as any as number;
      window.console.log("Student",this.id);
      this.assignStudentDetail(this.id);
    })
  }

  assignStudentDetail(id: number) {
    this.studentService.getStudentDetailById(id).subscribe(data => {
      this.studentDetail = data;
      this.rollNumber = this.studentDetail.rollNumber;
      window.console.log(this.rollNumber);
    });
  }

  checkActiveClasses() {
     
  }

  showPerformance() {
    this.performanceService.getPerformance().subscribe(data => {
      this.performanceList = data;
      this.individialPerformance = this.performanceList.filter(performance => performance.rollNumber == this.rollNumber);
      window.console.log(this.individialPerformance);
    })
    this.showPerformanceList = true;
  }

  selectedClass(classLink:string){
    window.open(classLink);
  }

  goToHome() {
    this.router.navigate(['/login']);
  }

  selectedProgram(programLink: string) {
    window.open(programLink);
  }

  redirectToQuiz() {
    this.router.navigate([`/student/${this.id}/quiz/${this.id}`]);
  }

}
