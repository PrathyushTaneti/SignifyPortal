import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ActiveMeetingsService } from '../Services/active-meetings.service';
import { AppServiceService } from '../Services/app.service';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html'
})
export class TeacherComponent implements OnInit {
  activeMeetings!: Observable<any[]>;

  constructor(private service : AppServiceService, private meetingsService : ActiveMeetingsService, private router :  Router) { }

  ngOnInit(): void {
    this.activeMeetings = this.meetingsService.getActiveMeetingsList();
  }

  checkActiveClasses() {
      window.console.log("HHH");
    if(this.service.activeMeetings.length == 0) window.console.log("Hell;o")
  }

  selectedClass(classLink:string){
    window.open(classLink);
  }

  goToHome() {
    this.router.navigate(['/login']);
  }

}
