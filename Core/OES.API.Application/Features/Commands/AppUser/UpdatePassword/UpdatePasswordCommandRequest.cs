using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandRequest: IRequest<UpdatePasswordCommandResponse>
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
