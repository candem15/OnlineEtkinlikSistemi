using OES.API.Domain.Entities;
using System.Text.Json.Serialization;

namespace OES.API.Domain.Identity
{
    public class AppUser : BaseUser
    {
        public string Surname { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event>? Events { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event>? Organizations { get; set; }
    }
}
