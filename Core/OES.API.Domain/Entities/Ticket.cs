using OES.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
