import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { CreateUser } from 'src/app/contracts/create_user';
import { User } from 'src/app/entities/user';
import { CustomToastrService } from '../services/custom-toastr.service';
import { HttpClientService } from '../services/http-client.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClientService: HttpClientService, private toastrService: CustomToastrService) { }

  async create(user: User): Promise<CreateUser> {
    const observable: Observable<CreateUser | User> = await this.httpClientService.post<CreateUser | User>({
      controller: "user",
      action: "create-user"
    }, user);

    return await firstValueFrom(observable) as CreateUser;
  }
}
