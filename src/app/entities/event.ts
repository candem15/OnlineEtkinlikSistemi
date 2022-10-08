export class Event {
  eventName: string;
  address: string;
  applicationDeadline: Date;
  eventDate: Date;
  description: string;
  categoryId: string;
  cityId: string;
  maxParticipantsNumber: number;
  ticketPrice?: number;
}
