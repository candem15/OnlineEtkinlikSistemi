using Microsoft.AspNetCore.Identity;
using OES.API.Domain.Entities;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
