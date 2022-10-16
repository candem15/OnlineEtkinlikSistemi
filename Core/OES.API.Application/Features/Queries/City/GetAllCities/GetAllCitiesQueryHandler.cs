using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Queries.City.GetAllCities
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQueryRequest, GetAllCitiesQueryResponse>
    {
        private readonly ICityService _cityService;

        public GetAllCitiesQueryHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<GetAllCitiesQueryResponse> Handle(GetAllCitiesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _cityService.GetAllAsync();
        }
    }
}
