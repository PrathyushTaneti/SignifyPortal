import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AppServiceService } from '../Services/app.service';
import { TeacherService } from '../Services/employee.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
})
export class EmployeeDetailsComponent implements OnInit {
  allEmployeeDetails!: Observable<any[]>;
  constructor(private service: TeacherService) { }

  ngOnInit(): void {
    this.allEmployeeDetails = this.service.getEmployeeList();
  }

  deleteEmployee(id: any) {
    this.service.deleteEmployeeDetails(id).subscribe();
    window.location.reload();
  }
}
