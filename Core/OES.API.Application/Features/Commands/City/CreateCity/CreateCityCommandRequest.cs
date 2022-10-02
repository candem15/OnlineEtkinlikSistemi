using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.City.CreateCity
{
    public class CreateCityCommandRequest : IRequest<CreateCityCommandResponse>
    {
        public string CityName { get; set; }
    }
}
