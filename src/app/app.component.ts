import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from './services/custom-toastr.service';

declare var $: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'OES.Client';
  constructor(
    public authService: AuthService,
    private toastrService: CustomToastrService) {
    this.userRoleCheck(localStorage.getItem("userRole"));
    this.authService.identityCheck();
  }

  signOut() {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("userRole");
    this.authService.identityCheck();
    this.userRoleCheck("");
    this.toastrService.notification(
      "Online etkinlik sistemine tekrar bekleriz. İyi günler dileriz.",
      "Çıkış başarılı!",
      ToastrMessageType.Info,
      ToastrPosition.TopRight
    )
  }

  async userRoleCheck(userType: string) {
    if (userType == "Basit") {

    } else if (userType == "Firma") {

    }
    else if (userType == "Admin") {
      $("#admin-event").removeClass("visually-hidden");
      $("#admin-category").removeClass("visually-hidden");
    }
    else {
      $("#admin-event").addClass("visually-hidden");
      $("#admin-category").addClass("visually-hidden");
    }
  }

}
