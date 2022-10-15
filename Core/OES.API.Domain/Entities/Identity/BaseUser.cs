﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Identity
{
    public class BaseUser : IdentityUser<string>
    {
        public string Name { get; set; }

    }
}
