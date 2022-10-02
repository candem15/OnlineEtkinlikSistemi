using OES.API.Application.Abstractions.Services;
using OES.API.Application.Features.Commands.Event.CreateEvent;
using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Services
{
    public class EventService : IEventService
    {
        private IEventReadRepository _eventReadRepository;
        private ICategoryReadRepository _categoryReadRepository;
        private IEventWriteRepository _eventWriteRepository;
        private ICityReadRepository _cityReadRepository;
        public EventService(IEventReadRepository eventReadRepository, IEventWriteRepository eventWriteRepository, ICategoryReadRepository categoryReadRepository, ICityReadRepository cityReadRepository)
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _cityReadRepository = cityReadRepository;
        }
        public async Task<CreateEventCommandResponse> CreateAsync(CreateEventCommandRequest createEvent)
        {
            Guid eventId = Guid.NewGuid();
            Event newEvent = new Event()
            {
                Id = eventId,
                EventDate = createEvent.EventDate,
                EventConfirmation = false,
                EventName = createEvent.EventName,
                ApplicationDeadline = createEvent.ApplicationDeadline,
                Address = createEvent.Address,
                Description = createEvent.Description,
                City = await _cityReadRepository.GetByIdAsync(createEvent.CityId),
                Category = await _categoryReadRepository.GetByIdAsync(createEvent.CategoryId),
                Ticket = createEvent.TicketPrice != null ? new Ticket() { EventId = eventId, TicketPrice = (double)createEvent.TicketPrice } : null,
                Quota = new Quota() { EventId = eventId, MaxParticipantsNumber = (int)createEvent.MaxParticipantsNumber, NumberOfParticipants = 0 }
            };
            await _eventWriteRepository.AddAsync(newEvent);
            await _eventWriteRepository.SaveChangesAsync();
            return new CreateEventCommandResponse { Message = $"{createEvent.EventName} isimli etkinlik başarıyla oluşturulmuştur!", Succeeded = true };
        }
    }
}
