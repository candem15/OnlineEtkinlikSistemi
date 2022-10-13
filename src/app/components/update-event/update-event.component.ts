import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ListConfirmedEvents } from 'src/app/contracts/list_confirmed_events';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { EventService } from 'src/app/services/event.service';
import { HttpClientService } from 'src/app/services/http-client.service';
import { BaseComponent, SpinnerType } from '../base/base.component';
import { ExpandableElements } from '../join-events/join-events.component';

@Component({
  selector: 'app-update-event',
  templateUrl: './update-event.component.html',
  styleUrls: ['./update-event.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class UpdateEventComponent extends BaseComponent implements OnInit {

  constructor(private formBuilder: UntypedFormBuilder,
    spinner: NgxSpinnerService,
    private toastrService: CustomToastrService,
    private eventService: EventService,
    private httpClientService: HttpClientService) {
    super(spinner);
  }

  displayedColumns: string[] = ['EventName', 'CategoryName', 'CityName', 'Description', 'Address', 'NumberOfParticipants', 'MaxParticipantsNumber', 'TicketPrice', 'ApplicationDeadline', 'EventDate', 'UpdateEvent', 'EventConfirmation', 'CancelEvent'];
  dataSource: MatTableDataSource<ListConfirmedEvents> = null;
  columnsToDisplayWithExpand = [...this.displayedColumns, 'expand'];
  expandedElement: ExpandableElements | null;
  modifiedEvent: ModifyEventInput = { id: null, eventName: null, address: null, maxParticipantsNumber: null };
  frmUpdateEvent: UntypedFormGroup;
  eventSubmitted: boolean = false;
  dateNow: Date = new Date();

  async getEventsByOrganizer() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allConfirmedEvents: { events: ListConfirmedEvents[] } = await this.eventService.getEventsByOrganizer(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));
    this.dataSource = new MatTableDataSource<ListConfirmedEvents>(allConfirmedEvents.events);

  }

  async modifyEvent(id: string, name: string, address: string, quota: number) {
    this.modifiedEvent.id = id;
    this.frmUpdateEvent.get('id').setValue(id);
    this.frmUpdateEvent.get('address').setValue(address);
    this.frmUpdateEvent.get('maxParticipantsNumber').setValue(quota);
    this.modifiedEvent.eventName = name;
  }

  async ngOnInit() {
    this.frmUpdateEvent = this.formBuilder.group({
      id: ["",
        [
          Validators.required
        ]],
      address: ["",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(250),
        ]],
      maxParticipantsNumber: [Number,
        [
          Validators.required,
          Validators.min(2)
        ]]
    })
    await this.getEventsByOrganizer();
  }

  get componentUpdateEvent() {
    return this.frmUpdateEvent.controls;
  }

  async onSubmit(event: ModifyEventInput) {
    this.eventSubmitted = true;
    if (this.frmUpdateEvent.invalid) {
      this.toastrService.notification("Etkinlik için hatalı değerler girdiniz. Lütfen girdilerinizi kontrol ediniz.", "Uyarı!", ToastrMessageType.Warning, ToastrPosition.TopRight);
      return;
    }
    this.showSpinner(SpinnerType.BallClipRotatePulse);
    await this.eventService.updateEvent(event, () => {
      this.toastrService.notification("Etkinlik güncellenmiştir.", "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight)
      this.hideSpinner(SpinnerType.BallClipRotatePulse)
      this.getEventsByOrganizer();
    }, () => {
      this.toastrService.notification("Bilinmeyen bir nedenden ötürü etkinlik güncellenemedi", "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    });
  }

  async cancelEvent(id: string, date: Date) {
    this.dateNow.setDate(this.dateNow.getDate() - 5)
    if (this.dateNow > new Date(date)) {
      this.toastrService.notification("Etkinliğin son başvuru tarihi geçtiği veya 5 günden az kaldığı için iptal edilemez!", "Hata!", ToastrMessageType.Warning, ToastrPosition.TopRight)
      return;
    }
    this.showSpinner(SpinnerType.BallClipRotatePulse);
    this.eventService.cancelEvent(id, () => {
      this.toastrService.notification("Etkinlik iptal edildi.", "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight);
      this.getEventsByOrganizer();
    }, (message) => {
      this.toastrService.notification(message, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight)
    })
    this.hideSpinner(SpinnerType.BallClipRotatePulse);
  }
}

export interface ModifyEventInput {
  id: string;
  eventName?: string;
  address: string;
  maxParticipantsNumber: number;
}
