import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CreateCity } from '../contracts/create_city';
import { ListCities } from '../contracts/list_cities';
import { UpdateCity } from '../contracts/update_city';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private httpClientService: HttpClientService) { }

  async read(
    successCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void): Promise<{ cities: ListCities[] }> {
    const promiseData: Promise<{ cities: ListCities[] }> =
      firstValueFrom(
        this.httpClientService.get<{ cities: ListCities[] }>({
          controller: "city",
          action: "get-all-cities"
        }));

    promiseData.then(_ => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }

  create(city: CreateCity, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.post({
      controller: "city",
      action:"create-city"
    }, city)
      .subscribe(result => {
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

  async delete(id: string, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.delete({
      controller: "city",
      action: "delete-city"
    }, id).subscribe(result => {
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

  async update(city: UpdateCity, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.post({
      controller: "city",
      action:"update-city"
    }, city)
      .subscribe(result => {
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
