import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ResponseInfo } from 'src/app/contracts/response_info';
import { LoginUser } from 'src/app/contracts/login_user';
import { User } from 'src/app/entities/user';
import { AuthService } from 'src/app/services/auth.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { UserAuthService } from 'src/app/services/user-auth.service';
import { UserService } from 'src/app/services/user.service';
import { BaseComponent, SpinnerType } from '../base/base.component';
import { delay } from 'rxjs';

declare var $: any;

@Component({
  selector: 'app-register-login',
  templateUrl: './register-login.component.html',
  styleUrls: ['./register-login.component.scss']
})
export class RegisterLoginComponent extends BaseComponent implements OnInit {

  constructor(
    private formBuilder: UntypedFormBuilder,
    private toastrService: CustomToastrService,
    private userAuthService: UserAuthService,
    spinner: NgxSpinnerService,
    private authService: AuthService,
    private userService: UserService,
    private activatedRoute: ActivatedRoute,
    private router: Router,) {
    super(spinner);
  }

  frmLogin: UntypedFormGroup;
  frmRegister: UntypedFormGroup;
  registerSubmitted: boolean = false;
  loginSubmitted: boolean = false;

  ngOnInit(): void {
    this.frmRegister = this.formBuilder.group({
      name: ["",
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
        ]],
      surname: ["",
        [
          Validators.minLength(2),
          Validators.maxLength(50),
        ]],
      // websiteDomain: ["",
      //   [
      //     Validators.minLength(4),
      //     Validators.maxLength(50),
      //   ]],
      username: ["",
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50)
        ]],
      email: ["",
        [
          Validators.required,
          Validators.email
        ]],
      password: ["",
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(50)
        ]],
      passwordConfirm: ["",
        [
          Validators.required
        ]]
    })
    this.frmLogin = this.formBuilder.group({
      usernameOrEmail: [""],
      password: [""]
    })
  }

  get componentRegister() {
    return this.frmRegister.controls;
  }

  get componentLogin() {
    return this.frmLogin.controls;
  }

  async onLoginSubmit(user: LoginUser) {
    this.loginSubmitted = true;
    this.showSpinner(SpinnerType.BallClipRotatePulse);
    await this.userAuthService.login(user, () => {
      this.authService.identityCheck();
      this.activatedRoute.queryParams.subscribe(params => {
        const returnUrl: string = params["returnUrl"];
        if (returnUrl)
          this.router.navigate([returnUrl]);
      })
      this.hideSpinner(SpinnerType.BallClipRotatePulse)
    });
  }

  async onRegisterSubmit(user: User) {
    this.registerSubmitted = true;
    if (this.frmRegister.invalid)
      return;
    const result: ResponseInfo = await this.userService.create(user);
    if (result.succeeded) {
      this.router.navigate(["/"]);
      this.toastrService.notification(result.message, "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight)
    }
    else {
      this.toastrService.notification(result.message, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight)
    }
  }

  // async userRegisterType(userType: string) {
  //   if (userType == "basic") {
  //     $("#webAddressSection").fadeOut("fast");
  //     $("#surnameSection").fadeIn("fast");
  //   } else {
  //     $("#webAddressSection").removeClass("visually-hidden");
  //     $("#webAddressSection").fadeIn("fast");
  //     $("#surnameSection").fadeOut("fast");
  //   }
  // }

  async switchTabs(tabName: string) {

    if (tabName == "login") {
      $("#pills-register").attr("class", "tab-pane fade");
      $("#pills-login").attr("class", "tab-pane fade show active");
      $("#tab-login").attr("class", "nav-link active");
      $("#tab-register").attr("class", "nav-link");
    } else {
      $("#pills-login").attr("class", "tab-pane fade");
      $("#pills-register").attr("class", "tab-pane fade show active");
      $("#tab-register").attr("class", "nav-link active");
      $("#tab-login").attr("class", "nav-link");
    }
  }
}
