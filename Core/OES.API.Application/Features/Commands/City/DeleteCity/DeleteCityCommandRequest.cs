using MediatR;

namespace OES.API.Application.Features.Commands.City.DeleteCity
{
    public class DeleteCityCommandRequest : IRequest<DeleteCityCommandResponse>
    {
        public string Id { get; set; }
    }
}
