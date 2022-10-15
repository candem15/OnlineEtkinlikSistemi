using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Identity
{
    public class AppCompany : BaseUser
    {
        public string WebsiteDomain { get; set; }
    }
}
