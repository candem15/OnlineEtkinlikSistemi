using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
