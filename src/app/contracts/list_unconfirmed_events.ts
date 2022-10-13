export class ListUnconfirmedEvents {
  id: string;
  eventName: string;
  address: string;
  applicationDeadline: Date;
  eventDate: Date;
  description?: string;
  eventConfirmation: boolean;
  categoryName: string;
  cityName: string;
  quota: number;
  ticketPrice?: number;
}
