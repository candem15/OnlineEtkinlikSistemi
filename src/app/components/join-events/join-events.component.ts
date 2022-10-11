import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, NgIterable, OnInit, ViewChild } from '@angular/core';
import { MatOption } from '@angular/material/core';
import { MatSelect } from '@angular/material/select';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable, of } from 'rxjs';
import { ListCompaniesToBuyTicket } from 'src/app/contracts/list_companies_to_buy_ticket';
import { ListConfirmedEvents } from 'src/app/contracts/list_confirmed_events';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { EventService } from 'src/app/services/event.service';
import { HttpClientService } from 'src/app/services/http-client.service';
import { BaseComponent, SpinnerType } from '../base/base.component';

@Component({
  selector: 'app-join-events',
  templateUrl: './join-events.component.html',
  styleUrls: ['./join-events.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class JoinEventsComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService,
    private toastrService: CustomToastrService,
    private eventService: EventService,
    private httpClientService: HttpClientService) {
    super(spinner);
  }

  displayedColumns: string[] = ['EventName', 'CategoryName', 'CityName', 'Description', 'Address', 'NumberOfParticipants', 'MaxParticipantsNumber', 'TicketPrice', 'ApplicationDeadline', 'EventDate', 'JoinEvent', 'BuyTicket'];
  dataSource: MatTableDataSource<ListConfirmedEvents> = null;
  columnsToDisplayWithExpand = [...this.displayedColumns, 'expand'];
  expandedElement: ExpandableElements | null;
  categories: any = [];
  cities: any = [];
  companies: ListCompaniesToBuyTicket[] = [];
  @ViewChild('matRefCategory') matRefCategory: MatSelect;
  @ViewChild('matRefCity') matRefCity: MatSelect;

  async getAllConfirmedEvents() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allConfirmedEvents: { events: ListConfirmedEvents[] } = await this.eventService.readConfirmedEvents(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));
    this.dataSource = new MatTableDataSource<ListConfirmedEvents>(allConfirmedEvents.events);
    this.categories = this.distinct(allConfirmedEvents.events, "categoryName");
    this.cities = this.distinct(allConfirmedEvents.events, "cityName");
    this.matRefCategory.options.forEach((data: MatOption) => data.deselect());
    this.matRefCity.options.forEach((data: MatOption) => data.deselect());
  }


  async applyFilter($event: any, filterBy: string) {
    $event.value = $event.value.trim();
    $event.value = $event.value.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    if (filterBy == "category")
      this.dataSource.filterPredicate = function (record, filter) {
        return record.categoryName.toLowerCase() == filter.toLowerCase();
      }
    else
      this.dataSource.filterPredicate = function (record, filter) {
        return record.cityName.toLowerCase() == filter.toLowerCase();
      }

    this.dataSource.filter = $event.value;
  }

  async buyTicket($event: any, eventId: string) {
    window.open(`https://${$event.value}`);
    this.joinToEvent(eventId);
  }

  async joinToEvent(eventId: string) {
    this.showSpinner(SpinnerType.SquareLoader);
    this.eventService.joinToEvent(eventId, () => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification("Etkinliğe başarıyla katılım sağladınız.", "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight)
    }, errorMessage => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification("Bu etkinliğe zaten katıldınız.", "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight)
    })
  }

  async getCompanies() {
    const companies: { companies: ListCompaniesToBuyTicket[] } = await this.eventService.getCompaniesToBuyTicket(() => { },
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));
    debugger;
    this.companies = companies.companies;

  }

  async refreshEvents() {
    await this.getAllConfirmedEvents();
  }

  async ngOnInit() {
    await this.getAllConfirmedEvents();
    await this.getCompanies();
  }

  distinct<T extends Record<K, string | number | boolean>,
    K extends keyof T>(arr: T[], ...keys: K[]): Pick<T, K>[] {
    const key = (obj: T) => JSON.stringify(keys.map(k => obj[k]));
    const val = (obj: T) => keys.reduce((a, k) => (a[k] = obj[k], a), {} as Pick<T, K>);
    const dict = arr.reduce((a, t) => (a[key(t)] = val(t), a), {} as { [k: string]: Pick<T, K> })
    return Object.values(dict);
  }
}

export interface ExpandableElements {
  description: string;
  address: string;
}

export interface CategoryFilter {
  categoryName: string;
}
