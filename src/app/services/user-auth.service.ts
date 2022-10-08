import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { AppComponent } from '../app.component';
import { LoginUser } from '../contracts/login_user';
import { TokenResponse } from '../contracts/token_response';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from './custom-toastr.service';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {

  constructor(private httpClientService: HttpClientService, private toastrService: CustomToastrService) { }

  async login(user: LoginUser, callBackFunction?: () => void) {
    const observable: Observable<any> = this.httpClientService.post({
      controller: "auth",
      action: "login"
    }, user);

    const tokenResponse = await firstValueFrom(observable).catch((error) => { console.log(error) }) as TokenResponse;
    if (tokenResponse) {
      localStorage.setItem("accessToken", tokenResponse.token.accessToken);
      localStorage.setItem("userRole", tokenResponse.userRole);
      //this.appComponent.userRoleCheck(tokenResponse.userRole);
      this.toastrService.notification(
        "Hoşgeldiniz! Online Etkinlik Sisteminin güzelliklerinin tadını çıkarmaya başlayabilirsiniz <3",
        "Giriş başarılı!",
        ToastrMessageType.Success, ToastrPosition.TopRight)
    }
    else{
      this.toastrService.notification(
        "Hatalı kullanıcı adı veya şifre girdiniz. Lütfen tekrar deneyiniz yada kayıt olunuz.",
        "Giriş başarısız!",
        ToastrMessageType.Error, ToastrPosition.TopRight)
    }
    callBackFunction();
  }
}
