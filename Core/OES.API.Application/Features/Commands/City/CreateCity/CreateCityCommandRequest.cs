using MediatR;

namespace OES.API.Application.Features.Commands.City.CreateCity
{
    public class CreateCityCommandRequest : IRequest<CreateCityCommandResponse>
    {
        public string CityName { get; set; }
    }
}
