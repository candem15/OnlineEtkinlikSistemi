import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ListUnconfirmedEvents } from 'src/app/contracts/list_unconfirmed_events';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { EventService } from 'src/app/services/event.service';
import { BaseComponent, SpinnerType } from '../base/base.component';

@Component({
  selector: 'app-admin-event',
  templateUrl: './admin-event.component.html',
  styleUrls: ['./admin-event.component.scss']
})
export class AdminEventComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService,
    private toastrService:CustomToastrService,
    private eventService:EventService) {
    super(spinner);
  }

  displayedColumns: string[] = ['EventName', 'Address', 'ApplicationDeadline', 'EventDate', 'Description', 'EventConfirmation', 'CategoryName', 'CityName','Quota','TicketPrice'];
  dataSource: MatTableDataSource<ListUnconfirmedEvents> = null;

  async getAllUnconfirmedEvents() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allUnconfirmedEvents: {  events: ListUnconfirmedEvents[] } = await this.eventService.read(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage,"Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));

    this.dataSource = new MatTableDataSource<ListUnconfirmedEvents>(allUnconfirmedEvents.events);
  }

  async ngOnInit() {
    await this.getAllUnconfirmedEvents();
  }
}
