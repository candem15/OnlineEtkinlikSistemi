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
        public string Ad { get; set; }
        public ICollection<Etkinlik>? Etkinlikler { get; set; }
        public string? WebSitesi { get; set; }
    }
}
