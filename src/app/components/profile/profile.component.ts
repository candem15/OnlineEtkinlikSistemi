import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { delay, of, Subscription } from 'rxjs';
import { UserDetails } from 'src/app/contracts/user_details';
import { AuthService } from 'src/app/services/auth.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { UserService } from 'src/app/services/user.service';
import { BaseComponent, SpinnerType } from '../base/base.component';

declare var $: any;

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService,
    private userService: UserService,
    private toastrService: CustomToastrService,
    public authService: AuthService) {
    super(spinner)
  }
  passwordFormControl = new FormControl('', [Validators.required, Validators.minLength(8)]);

  subscription: Subscription;
  user: any;
  toggleTab: boolean = true;

  async getProfileDetails() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allDetails: { userDetails: UserDetails } = await this.userService.read(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));
    return of({ allDetails }).pipe(delay(2000));
  }

  async updatePassword(newPassword: HTMLInputElement) {
    if (newPassword.value == "") {
      this.toastrService.notification("Şifreyi boş geçmeyiniz.",
        "Bilgilendirme!",
        ToastrMessageType.Warning,
        ToastrPosition.TopRight
      );
      return;
    }
    this.showSpinner(SpinnerType.SquareLoader);
    this.userService.updatePassword(newPassword.value, () => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification("Şifreniz güncellendi.",
        "Başarılı!",
        ToastrMessageType.Success,
        ToastrPosition.TopRight
      );
    }, errorMessage => {
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    }
    );
  }

  async refreshProfileDetails() {
    await this.getProfileDetails();
  }

  async ngOnInit() {
    this.subscription = (await this.getProfileDetails()).subscribe(u => (this.user = u.allDetails));
    await this.getProfileDetails();
  }

  async toggleToPasswordChange() {
    $("#profile-tab").removeClass("active");
    $("#pass-tab").addClass("active");
    this.toggleTab = false;
  }
  async toggleToProfile() {
    $("#pass-tab").removeClass("active");
    $("#profile-tab").addClass("active");
    this.toggleTab = true;
  }
}
