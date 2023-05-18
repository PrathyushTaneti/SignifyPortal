import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthGuardService implements CanActivate, CanActivateChild {

  constructor(private router: Router, private jwt: JwtHelperService) { }

  canActivate() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwt.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(['/']);
    return false;
  }

  canActivateChild() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwt.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(['/']);
    return false;
  }
}
