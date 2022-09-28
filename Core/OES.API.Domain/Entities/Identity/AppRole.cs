using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public string Name { get; set; }
    }
}
