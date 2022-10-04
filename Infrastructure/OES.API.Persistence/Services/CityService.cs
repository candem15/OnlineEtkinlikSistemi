using OES.API.Application.Abstractions.Services;
using OES.API.Application.Features.Commands.City.CreateCity;
using OES.API.Application.Features.Commands.City.DeleteCity;
using OES.API.Application.Features.Commands.City.UpdateCity;
using OES.API.Application.Features.Queries.City.GetAllCities;
using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Services
{
    public class CityService : ICityService
    {
        private ICityWriteRepository _cityWriteRepository;
        private ICityReadRepository _cityReadRepository;
        public CityService(ICityWriteRepository cityWriteRepository, ICityReadRepository cityReadRepository)
        {
            _cityWriteRepository = cityWriteRepository;
            _cityReadRepository = cityReadRepository;
        }

        public async Task<CreateCityCommandResponse> CreateAsync(City city)
        {
            bool cityExists = _cityReadRepository.GetWhere(x => x.CityName == city.CityName).Any();
            if (cityExists)
            {
                return new CreateCityCommandResponse() { Message = "Bu isimde hali hazırda bir şehir vardır!", Succeeded = false };
            }
            else
            {
                await _cityWriteRepository.AddAsync(city);
                await _cityWriteRepository.SaveChangesAsync();
                return new CreateCityCommandResponse() { Message = $"{city.CityName} isimli şehir başarıyla oluşturulmuştur!", Succeeded = true };
            }
        }

        public async Task<UpdateCityCommandResponse> UpdateAsync(City city)
        {
            City cityToUpdate = await _cityReadRepository.GetByIdAsync(city.Id.ToString());
            if (cityToUpdate == null)
            {
                return new UpdateCityCommandResponse { Message = "Adını güncellemek istediğiniz şehir mevcut değildir!", Succeeded = false };
            }
            else
            {
                cityToUpdate.CityName = city.CityName;
                _cityWriteRepository.Update(cityToUpdate);
                await _cityWriteRepository.SaveChangesAsync();
                return new UpdateCityCommandResponse { Message = $"Şehir ismi {cityToUpdate.CityName} olarak başarıyla güncellenmiştir!" };
            }
        }

        public async Task<DeleteCityCommandResponse> DeleteAsync(string cityId)
        {
            City cityToDelete = await _cityReadRepository.GetByIdAsync(cityId);
            if (cityToDelete == null)
                return new DeleteCityCommandResponse { Message = "Silmek istediğiniz şehir mevcut değildir!", Succeeded = false };
            await _cityWriteRepository.RemoveAsync(cityId);
            await _cityWriteRepository.SaveChangesAsync();
            return new DeleteCityCommandResponse { Message = $"{cityToDelete.CityName} isimli şehir başarıyla silinmiştir!", Succeeded = true };
        }

        public async Task<GetAllCitiesQueryResponse> GetAllCitiesAsync()
        {
            List<City> cities = _cityReadRepository.GetAll().ToList();

            return new GetAllCitiesQueryResponse() { Cities = cities };
        }
    }
}
