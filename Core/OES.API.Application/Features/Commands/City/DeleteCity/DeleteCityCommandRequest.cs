using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.City.DeleteCity
{
    public class DeleteCityCommandRequest : IRequest<DeleteCityCommandResponse>
    {
        public string Id { get; set; }
    }
}
