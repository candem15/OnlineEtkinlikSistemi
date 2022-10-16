using MediatR;

namespace OES.API.Application.Features.Commands.City.UpdateCity
{
    public class UpdateCityCommandRequest : IRequest<UpdateCityCommandResponse>
    {
        public string Id { get; set; }
        public string CityName { get; set; }
    }
}
