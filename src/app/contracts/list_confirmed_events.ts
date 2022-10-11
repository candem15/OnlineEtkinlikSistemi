export class ListConfirmedEvents{
  id: string;
  eventName: string;
  address: string;
  applicationDeadline: Date;
  eventDate: Date;
  description?: string;
  categoryName: string;
  cityName: string;
  numberOfParticipants: number;
  maxParticipantsNumber: number;
  ticketPrice?: number;
}
