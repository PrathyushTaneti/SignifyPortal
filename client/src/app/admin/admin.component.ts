import { Component, OnInit } from '@angular/core';
import { MatDrawerContainer } from '@angular/material/sidenav';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  providers: []
})

export class AdminComponent implements OnInit {
  showFiller = false;
  hasBackDrop = true;

  public user!: { id: string, name: string };

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private jwt: JwtHelperService) { }

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

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.user.id = data['id'],
        this.user.name = data['name']
    });
  }
}

