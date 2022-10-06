import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ListUnconfirmedEvents } from '../contracts/list_unconfirmed_events';
import { CustomToastrService } from './custom-toastr.service';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private httpClientService: HttpClientService,private toastrService:CustomToastrService) { }

  async read(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{  events: ListUnconfirmedEvents[] }> {
    const promiseData: Promise<{ events: ListUnconfirmedEvents[] }> =
      firstValueFrom(
        this.httpClientService.get<{ events: ListUnconfirmedEvents[] }>({
          controller: "event",
          action:"get-unconfirmed-events"
        }));

    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }
}
