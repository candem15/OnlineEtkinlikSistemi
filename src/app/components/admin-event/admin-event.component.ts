import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmEvent } from 'src/app/contracts/confirm_event';
import { ListUnconfirmedEvents } from 'src/app/contracts/list_unconfirmed_events';
import { RejectEvent } from 'src/app/contracts/reject_event';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { EventService } from 'src/app/services/event.service';
import { HttpClientService } from 'src/app/services/http-client.service';
import { BaseComponent, SpinnerType } from '../base/base.component';

declare var $: any;

@Component({
  selector: 'app-admin-event',
  templateUrl: './admin-event.component.html',
  styleUrls: ['./admin-event.component.scss']
})
export class AdminEventComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService,
    private toastrService: CustomToastrService,
    private eventService: EventService,
    private httpClientService: HttpClientService) {
    super(spinner);
  }

  displayedColumns: string[] = ['EventName', 'CategoryName', 'CityName', 'Description', 'Address', 'Quota', 'TicketPrice', 'ApplicationDeadline', 'EventDate', 'EventConfirmation', 'ConfirmEvent', 'RejectEvent'];
  dataSource: MatTableDataSource<ListUnconfirmedEvents> = null;

  async getAllUnconfirmedEvents() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allUnconfirmedEvents: { events: ListUnconfirmedEvents[] } = await this.eventService.read(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));

    this.dataSource = new MatTableDataSource<ListUnconfirmedEvents>(allUnconfirmedEvents.events);
  }

  async rejectEvent(id: string) {
    const rejectEvent: RejectEvent = new RejectEvent();
    rejectEvent.id = id;
    this.showSpinner(SpinnerType.SquareLoader)
    this.eventService.rejectEvent(rejectEvent, async () => {
      this.toastrService.notification("Etkinlik reddedildi.", "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight);
      await this.refreshEvents();
    }, errorMessage => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    });
  }

  async confirmEvent(id: string) {
    const confirmEvent: ConfirmEvent = new ConfirmEvent();
    confirmEvent.id = id;
    this.showSpinner(SpinnerType.SquareLoader)
    this.eventService.confirmEvent(confirmEvent, async () => {
      this.toastrService.notification("Etkinlik onaylandı.", "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight);
      await this.refreshEvents();
    }, errorMessage => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    });
  }

  async refreshEvents() {
    await this.getAllUnconfirmedEvents();
  }

  async ngOnInit() {
    await this.getAllUnconfirmedEvents();
  }
}
