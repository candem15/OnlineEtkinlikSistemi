using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Dtos.Event
{
    public class GetEventsByUserResponse
    {
        public string EventName { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public int MaxParticipantsNumber { get; set; }
        public double? TicketPrice { get; set; }
        public bool Participation { get; set; }
    }
}
