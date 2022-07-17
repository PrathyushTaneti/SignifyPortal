import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Performance } from '../Models/performance.model';
import { Student } from '../Models/student.model';
import { PerformanceService } from '../Services/performance.service';
import { StudentService } from '../Services/student.service';


@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
})
  
export class QuizComponent implements OnInit {
  quizForm!: FormGroup;
  result: number = 0;
  public resultString!: string;
  public showResult: boolean = false;
  public hideForm: boolean = true;
  public id!: number;
  public rollNumber!: string;
  public studentDetail!: Student;
  public performanceForm!: FormGroup;
  perFormanceList!: Performance[];

  constructor(private performanceService: PerformanceService, private activeRouter : ActivatedRoute, private studentService : StudentService) { }

  ngOnInit(): void {
    this.buildForm();
    this.activeRouter.paramMap.subscribe((parameter) => {
      this.id = parameter.get('id') as any as number;
      window.console.log("Quiz", this.id);
      this.studentService.getStudentDetailById(this.id).subscribe(data => {
        this.studentDetail = data;
        this.rollNumber = this.studentDetail.rollNumber;
        window.console.log(this.studentDetail);
      });
    })
    this.performanceService.getPerformance().subscribe(data => {
      this.perFormanceList = data;
      window.console.log("PerformanceList",this.perFormanceList);
    })
  }

  buildForm() {
    this.quizForm = new FormGroup({
      questionOne: new FormControl('', Validators.required),
      questionTwo: new FormControl('', Validators.required),  
      questionThree: new FormControl('', Validators.required)   
    })
  }

  evaluateQuiz() {
    if (this.quizForm.valid) {
      window.console.log(this.quizForm.value);
      if (this.quizForm.get('questionOne')?.value == 'A' || this.quizForm.get('questionOne')?.value == 'a') {
        this.result += 1;        
      }
       if (this.quizForm.get('questionTwo')?.value == 'B' || this.quizForm.get('questionTwo')?.value == 'b') {
        this.result += 1;        
       }
       if (this.quizForm.get('questionThree')?.value == 'C' || this.quizForm.get('questionThree')?.value == 'C') {
        this.result += 1;        
      }
    }
    this.hideForm = false;
    this.showResult = true;
    this.result = Math.round((this.result / 3) * 100);
    this.resultString += this.result + "%";
    this.performanceForm = new FormGroup({
      rollNumber : new FormControl(this.rollNumber),
      performanceOfStudent: new FormControl(this.result.toString()+"%"),
      quizName: new FormControl('C++ Programming')
    })
    window.console.log(this.performanceForm.value);
    this.performanceService.postPerformance(this.performanceForm.value).subscribe();
  }
}
