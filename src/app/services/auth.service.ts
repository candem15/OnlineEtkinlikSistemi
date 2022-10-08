import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AppComponent } from '../app.component';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper: JwtHelperService) { }

  identityCheck() {

    const token: string = localStorage.getItem("accessToken")!;
    let expired: boolean;
    try {
      expired = this.jwtHelper.isTokenExpired(token);
    }
    catch {
      localStorage.removeItem("userRole");
      expired = true;
    }

    _isAuthenticated = token != null && !expired;
  }

  get userRoleCheck() {
    _userRole = localStorage.getItem("userRole");
    return _userRole;
  }

  get isAuthenticated() {
    return _isAuthenticated;
  }
}

export let _isAuthenticated: boolean;
export let _userRole: string;
