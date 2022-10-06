export class ListUnconfirmedEvents {
  Id: string;
  EventName: string;
  Address: string;
  ApplicationDeadline: Date;
  EventDate: Date;
  Description?: string;
  EventConfirmation: boolean;
  CategoryName: string;
  CityName: string;
  Quota: number;
  TicketPrice?: number;
}
