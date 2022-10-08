import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { ResponseInfo } from 'src/app/contracts/response_info';
import { User } from 'src/app/entities/user';
import { UserDetails } from '../contracts/user_details';
import { HttpClientService } from '../services/http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClientService: HttpClientService) { }

  async create(user: User): Promise<ResponseInfo> {
    const observable: Observable<ResponseInfo | User> = await this.httpClientService.post<ResponseInfo | User>({
      controller: "user",
      action: "create-user"
    }, user);

    return await firstValueFrom(observable) as ResponseInfo;
  }

  async read(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{ userDetails: UserDetails }> {
    const promiseData: Promise<{ userDetails: UserDetails }> =
      firstValueFrom(
        this.httpClientService.get<{ userDetails: UserDetails }>({
          controller: "user",
          action: "get-user-details"
        }));

    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }

  async updatePassword(Password: string, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    await this.httpClientService.post<ResponseInfo | { Password }>({
      controller: "user",
      action: "update-password"
    }, { Password }).subscribe(result => {
      successCallBack();
    }, (errorResponse: HttpErrorResponse) => {
      const _error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
      let message = "";
      _error.forEach((v, index) => {
        v.value.forEach((_v, index) => {
          message += `${_v}<br>`;
        });
      });
      errorCallBack(message);
    });
  }

}
