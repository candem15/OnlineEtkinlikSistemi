using AutoMapper;
using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.City.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommandRequest, UpdateCityCommandResponse>
    {
        private ICityService _cityService;
        private IMapper _mapper;
        public UpdateCityCommandHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }
        public async Task<UpdateCityCommandResponse> Handle(UpdateCityCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateCityCommandResponse response = await _cityService.UpdateAsync(_mapper.Map<Domain.Entities.City>(request));
            return response;
        }
    }
}
