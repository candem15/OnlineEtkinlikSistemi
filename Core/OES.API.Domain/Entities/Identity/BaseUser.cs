using Microsoft.AspNetCore.Identity;

namespace OES.API.Domain.Identity
{
    public class BaseUser : IdentityUser<string>
    {
        public string Name { get; set; }

    }
}
