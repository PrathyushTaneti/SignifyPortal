import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ActiveMeetings } from '../Models/activeMeetings.model';
import { ClassDetails } from '../Models/classDetails.model';
import { ActiveMeetingsService } from '../Services/active-meetings.service';
import { AppServiceService } from '../Services/app.service';

@Component({
  selector: 'app-schedule-meeting',
  templateUrl: './schedule-meeting.component.html',
})
export class ScheduleMeetingComponent implements OnInit {
  newMeetingForm!: FormGroup;
  public checkActiveMeetings: boolean = false;
  public activeMeetingsList!: ActiveMeetings[];

  constructor(private activeMeetingService : ActiveMeetingsService,private activeMeetingsService:ActiveMeetingsService ,private router : Router) { }

  ngOnInit(): void {
    this.buildForm();
    this.activeMeetingService.getActiveMeetingsList().subscribe(data => {
      this.activeMeetingsList = data;
      if (this.activeMeetingsList != null) {
        this.checkActiveMeetings = true;
      }
    })
  }

  buildForm() {
    this.newMeetingForm = new FormGroup({
      meetingLink: new FormControl('', [Validators.required]),
      subject: new FormControl('', [Validators.required])
    })
  }

  createMeeting() {
    if (this.newMeetingForm.valid) {
      window.console.log(this.newMeetingForm.get('meetingLink')?.value, this.newMeetingForm.get('subject')?.value);
      this.activeMeetingService.postMeeting(this.newMeetingForm.value).subscribe();
      window.location.reload();
      }     
  }

  joinMeeting(joinLink: string) {
    window.open(joinLink);    
  }

  endMeeting(meetingId:number) {
    this.activeMeetingService.deleteMeeting(meetingId).subscribe();
    window.location.reload();
  }
}
