namespace OES.API.Application.Dtos.Event
{
    public class ConfirmedEventsResponse
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public string Address { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public int NumberOfParticipants { get; set; }
        public int MaxParticipantsNumber { get; set; }
        public double? TicketPrice { get; set; }
    }
}
