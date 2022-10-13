import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { ModifyEventInput } from '../components/update-event/update-event.component';
import { ConfirmEvent } from '../contracts/confirm_event';
import { EventsByUser } from '../contracts/events_by_user';
import { ListCompaniesToBuyTicket } from '../contracts/list_companies_to_buy_ticket';
import { ListConfirmedEvents } from '../contracts/list_confirmed_events';
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

  async readUnconfirmedEvents(
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

  async readConfirmedEvents(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{ events: ListConfirmedEvents[] }> {
    const promiseData: Promise<{ events: ListConfirmedEvents[] }> =
      firstValueFrom(
        this.httpClientService.get<{ events: ListConfirmedEvents[] }>({
          controller: "event",
          action: "get-confirmed-events"
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

  async joinToEvent(eventId: string, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<any> {
    const promiseData: Promise<any> = firstValueFrom(this.httpClientService.put({
      controller: "event",
      action: "join-to-event"
    }, { eventId }));
    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));
    return await promiseData;
  }

  async getCompaniesToBuyTicket(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{ companies: ListCompaniesToBuyTicket[] }> {
    const promiseData: Promise<{ companies: ListCompaniesToBuyTicket[] }> =
      firstValueFrom(
        this.httpClientService.get<{ companies: ListCompaniesToBuyTicket[] }>({
          controller: "event",
          action: "get-companies-to-buy-ticket"
        }));

    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }

  async getEventsByOrganizer(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{ events: ListConfirmedEvents[] }> {
    const promiseData: Promise<{ events: ListConfirmedEvents[] }> =
      firstValueFrom(
        this.httpClientService.get<{ events: ListConfirmedEvents[] }>({
          controller: "event",
          action: "get-events-by-organizer"
        }));

    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }

  async getEventsByUser(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{ events: EventsByUser[] }> {
    const promiseData: Promise<{ events: EventsByUser[] }> =
      firstValueFrom(
        this.httpClientService.get<{ events: EventsByUser[] }>({
          controller: "event",
          action: "get-events-by-user"
        }));

    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }

  async updateEvent(event: ModifyEventInput, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.put({
      controller: "event",
      action: "update-event"
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

  async cancelEvent(eventId: string, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<any> {
    const promiseData: Promise<any> = firstValueFrom(this.httpClientService.delete({
      controller: "event",
      action: "delete-event"
    }, eventId));
    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));
    return await promiseData;
  }
}
