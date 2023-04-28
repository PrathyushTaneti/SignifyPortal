import { Component } from '@angular/core';
import { MatDrawerContainer } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html'
})

export class AdminComponent {
  showFiller = false;
  hasBackDrop = true;

  constructor(private router: Router, private jwt: JwtHelperService) { }

  isUserAuthenticated() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwt.isTokenExpired(token)) {
      return true;
    }
    return false;
  }

  Logout() {
    localStorage.removeItem("jwt");
    this.router.navigate(['./home/home']);
  }
}

