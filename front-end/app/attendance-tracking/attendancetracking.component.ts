import { Component, OnInit } from '@angular/core';
import { AttendanceTracker } from '../Models/attendance-tracker.model';
import { AttendanceTrackerService } from '../Services/attendance-tracker.service';

@Component({
  selector: 'app-attendancetracking',
  templateUrl: './attendancetracking.component.html',
})
export class AttendancetrackingComponent implements OnInit {
  public allAttendanceList!: AttendanceTracker[];
  public allStudentDetails!: AttendanceTracker[];
  public allTeacherDetails!: AttendanceTracker[];

  constructor(private attendanceService : AttendanceTrackerService) { }

  ngOnInit(): void {
    this.attendanceService.get().subscribe(data => {
      this.allAttendanceList = data;
      this.allStudentDetails = this.allAttendanceList.filter(subject => subject.designation == 'student');
      this.allTeacherDetails = this.allAttendanceList.filter(subject => subject.designation == 'teacher');
      window.console.log(this.allStudentDetails);
    });
  }
}
