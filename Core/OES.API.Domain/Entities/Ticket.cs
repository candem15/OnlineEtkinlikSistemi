using OES.API.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace OES.API.Domain.Entities
{
    public class Ticket : BaseEntity

    {
        public Guid EventId { get; set; }
        public double TicketPrice { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}
