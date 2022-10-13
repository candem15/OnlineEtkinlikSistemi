import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSelect } from '@angular/material/select';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventsByUser } from 'src/app/contracts/events_by_user';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { EventService } from 'src/app/services/event.service';
import { HttpClientService } from 'src/app/services/http-client.service';
import { BaseComponent, SpinnerType } from '../base/base.component';
import { ExpandableElements } from '../join-events/join-events.component';

@Component({
  selector: 'app-user-activities',
  templateUrl: './user-activities.component.html',
  styleUrls: ['./user-activities.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class UserActivitiesComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService,
    private toastrService: CustomToastrService,
    private eventService: EventService,
    private httpClientService: HttpClientService) {
    super(spinner);
  }

  displayedColumns: string[] = ['EventName', 'CategoryName', 'CityName', 'Description', 'Address', 'MaxParticipantsNumber', 'TicketPrice', 'EventDate', 'Participation'];
  dataSource: MatTableDataSource<EventsByUser> = null;
  columnsToDisplayWithExpand = [...this.displayedColumns, 'expand'];
  expandedElement: ExpandableElements | null;

  @ViewChild('matRefCategory') matRefCategory: MatSelect;
  @ViewChild('matRefCity') matRefCity: MatSelect;

  async getActivities() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allActivities: { events: EventsByUser[] } = await this.eventService.getEventsByUser(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));
    this.dataSource = new MatTableDataSource<EventsByUser>(allActivities.events);

  }

  async ngOnInit() {
    this.getActivities();
  }

  async applyFilter($event: any) {
    if ($event.value == "Participated")
      this.dataSource.filterPredicate = function (record, filter) {
        return record.participation.valueOf() == true;
      }
    else
      this.dataSource.filterPredicate = function (record, filter) {
        return record.participation.valueOf() == false;
      }
    this.dataSource.filter = $event.value;
  }
}
