using Microsoft.AspNetCore.Identity;
using OES.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
        public ICollection<Event>? Events { get; set; }
        public string? WebAddressUrl { get; set; }
    }
}
