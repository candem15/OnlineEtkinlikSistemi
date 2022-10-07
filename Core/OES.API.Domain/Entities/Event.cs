using Newtonsoft.Json;
using OES.API.Domain.Entities.Common;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Entities
{
    public class Event : BaseEntity
    {
        public Guid Id { get; set; }
        public string OrganizerId { get; set; }
        public string EventName { get; set; }
        public string Address { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public bool EventConfirmation { get; set; }
        [JsonIgnore]
        public virtual AppUser Organizer { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual City City { get; set; }
        [JsonIgnore]
        public virtual Quota Quota { get; set; }
        [JsonIgnore]
        public virtual Ticket? Ticket { get; set; }
        [JsonIgnore]
        public virtual ICollection<AppUser>? Users { get; set; }
    }
}
