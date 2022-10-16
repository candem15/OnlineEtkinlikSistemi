using OES.API.Application.Features.Commands.City.CreateCity;
using OES.API.Application.Features.Commands.City.DeleteCity;
using OES.API.Application.Features.Commands.City.UpdateCity;
using OES.API.Application.Features.Queries.City.GetAllCities;
using OES.API.Domain.Entities;

namespace OES.API.Application.Abstractions.Services
{
    public interface ICityService
    {
        Task<CreateCityCommandResponse> CreateAsync(City city);
        Task<UpdateCityCommandResponse> UpdateAsync(City city);
        Task<DeleteCityCommandResponse> DeleteAsync(string cityId);
        Task<GetAllCitiesQueryResponse> GetAllAsync();
    }
}
