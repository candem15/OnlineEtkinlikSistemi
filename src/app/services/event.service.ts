import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { ConfirmEvent } from '../contracts/confirm_event';
import { ListUnconfirmedEvents } from '../contracts/list_unconfirmed_events';
import { ResponseInfo } from '../contracts/response_info';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private httpClientService: HttpClientService) { }

  async create(event: Event): Promise<ResponseInfo> {
    const observable: Observable<ResponseInfo | Event> = await this.httpClientService.post<ResponseInfo | Event>({
      controller: "event",
      action: "create-event"
    }, event);

    return await firstValueFrom(observable) as ResponseInfo;
  }

  async read(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{ events: ListUnconfirmedEvents[] }> {
    const promiseData: Promise<{ events: ListUnconfirmedEvents[] }> =
      firstValueFrom(
        this.httpClientService.get<{ events: ListUnconfirmedEvents[] }>({
          controller: "event",
          action: "get-unconfirmed-events"
        }));

    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }

  async confirmEvent(event: ConfirmEvent, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.put({
      controller: "Event",
      action: "confirm-event"
    }, event).subscribe(result => {
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

  async rejectEvent(event: ConfirmEvent, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.put({
      controller: "Event",
      action: "reject-event"
    }, event).subscribe(result => {
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
