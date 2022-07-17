import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Admin } from '../Models/admin.model';
import { ClassDetails } from '../Models/classDetails.model';
import { NewMeeting } from '../Models/new-meeting';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {
  public adminDetails: Admin[];
  public isPresent: number = -1;
  public activeMeetings: ClassDetails[] = [];
  readonly signifyApiUrl = "https://localhost:44307/api";
  constructor(private router: Router, private activatedRoute: ActivatedRoute,
  private http:HttpClient) {
    this.adminDetails = [];
    this.defaultAdmins();
  }

  ngOnInit() {
  }

  defaultAdmins() {
    this.adminDetails.push(
      {
        emailAddress: "prathyush@signify.com",
        password:"admin"
      }  
    )
  }

  isAdminDetailPresent(args: Admin):boolean {
    this.isPresent = this.adminDetails.findIndex(admin => admin.emailAddress.toLowerCase() == args.emailAddress.toLowerCase());
    return this.isPresent < 0 ? false : true;
  }

  addActiveMeeting(args: ClassDetails) {
    this.activeMeetings.push(args);
    this.activeMeetings.forEach(contact => {
      window.console.log("From Service" ,contact.joinLink,contact.subject);
    })
  }

  getActiveMeetings() {
    return this.activeMeetings;
  }
}
