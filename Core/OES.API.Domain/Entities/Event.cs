using OES.API.Domain.Entities.Common;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string EventName { get; set; }
        public string Address { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public bool EventConfirmation { get; set; }
        public Category Category { get; set; }
        public City City { get; set; }
        public Quota Quota { get; set; }
        public Ticket? Ticket { get; set; }
        public ICollection<AppUser>? Users { get; set; }
    }
}
