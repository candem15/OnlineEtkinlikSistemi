import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs';
import { SpinnerType } from 'src/app/components/base/base.component';
import { _isAuthenticated } from 'src/app/services/auth.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../services/custom-toastr.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private jwtHelper: JwtHelperService,
    private toastrService: CustomToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) {

  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    this.spinner.show(SpinnerType.BallPulse);

    if (!_isAuthenticated) {
      this.toastrService.notification(
        "Bu sayfaya erişebilmek için lütfen giriş yapınız.",
        "Yetkisiz erişim!",
        ToastrMessageType.Warning,
        ToastrPosition.TopRight);

      this.router.navigate(["register"], { queryParams: { returnUrl: state.url } })
    }

    this.spinner.hide(SpinnerType.BallPulse);

    return true;
  }

}
