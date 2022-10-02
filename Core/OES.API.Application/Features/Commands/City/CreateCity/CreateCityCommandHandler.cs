using AutoMapper;
using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.City.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommandRequest, CreateCityCommandResponse>
    {
        private ICityService _cityService;
        private IMapper _mapper;

        public CreateCityCommandHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<CreateCityCommandResponse> Handle(CreateCityCommandRequest request, CancellationToken cancellationToken)
        {
            CreateCityCommandResponse response = await _cityService.CreateAsync(_mapper.Map<Domain.Entities.City>(request));
            return response;
        }
    }
}
