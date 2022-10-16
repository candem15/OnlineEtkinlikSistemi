using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.City.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommandRequest, DeleteCityCommandResponse>
    {
        private ICityService _cityService;

        public DeleteCityCommandHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<DeleteCityCommandResponse> Handle(DeleteCityCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteCityCommandResponse response = await _cityService.DeleteAsync(request.Id);
            return response;
        }
    }
}
