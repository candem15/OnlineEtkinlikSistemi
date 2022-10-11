using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Dtos.Event;
using OES.API.Application.Exceptions;
using OES.API.Application.Features.Commands.Event.ConfirmEvent;
using OES.API.Application.Features.Commands.Event.CreateEvent;
using OES.API.Application.Features.Commands.Event.DeleteEvent;
using OES.API.Application.Features.Commands.Event.JoinToEvent;
using OES.API.Application.Features.Commands.Event.RejectEvent;
using OES.API.Application.Features.Commands.Event.UpdateEvent;
using OES.API.Application.Features.Queries.Event.GetAllConfirmedEvents;
using OES.API.Application.Features.Queries.Event.GetAllEventsByUser;
using OES.API.Application.Features.Queries.Event.GetAllUnconfirmedEvents;
using OES.API.Application.Features.Queries.Event.GetCompaniesToBuyTicket;
using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using OES.API.Domain.Identity;
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
        private IQuotaReadRepository _quotaReadRepository;
        private IQuotaWriteRepository _quotaWriteRepository;
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;
        public EventService(IEventReadRepository eventReadRepository, IEventWriteRepository eventWriteRepository, ICategoryReadRepository categoryReadRepository, ICityReadRepository cityReadRepository, IQuotaReadRepository quotaReadRepository, IQuotaWriteRepository quotaWriteRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _cityReadRepository = cityReadRepository;
            _quotaReadRepository = quotaReadRepository;
            _quotaWriteRepository = quotaWriteRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<CreateEventCommandResponse> CreateAsync(CreateEventCommandRequest createEvent)
        {
            Guid newId = Guid.NewGuid();
            Event newEvent = new Event()
            {
                Id = newId,
                OrganizerId = createEvent.Id,
                EventDate = createEvent.EventDate,
                EventConfirmation = false,
                EventName = createEvent.EventName,
                ApplicationDeadline = createEvent.ApplicationDeadline,
                Address = createEvent.Address,
                Description = createEvent.Description,
                City = await _cityReadRepository.GetByIdAsync(createEvent.CityId),
                Category = await _categoryReadRepository.GetByIdAsync(createEvent.CategoryId),
                Ticket = createEvent.TicketPrice != null ? new Ticket() { EventId = newId, TicketPrice = (double)createEvent.TicketPrice } : null,
                Quota = new Quota() { EventId = newId, MaxParticipantsNumber = (int)createEvent.MaxParticipantsNumber, NumberOfParticipants = 0 }
            };
            await _eventWriteRepository.AddAsync(newEvent);
            await _eventWriteRepository.SaveChangesAsync();
            return new CreateEventCommandResponse { Message = $"{createEvent.EventName} isimli etkinlik başarıyla oluşturulmuştur!", Succeeded = true };
        }

        public async Task<UpdateEventCommandResponse> UpdateAsync(UpdateEventCommandRequest updateEvent)
        {
            Event eventToUpdate = await _eventReadRepository.GetByIdAsync(updateEvent.Id);
            if (eventToUpdate == null)
                return new UpdateEventCommandResponse { Message = "Güncellenmek istenen etkinlik bulunumadı!", Succeeded = false };
            if (eventToUpdate.ApplicationDeadline.Date < DateTime.UtcNow.AddDays(-5))
            {
                return new UpdateEventCommandResponse { Message = "Güncellenmek istenen etkinliğin başvurulara kapanma tarihine 5 günden az kaldığı için güncelleme işlemi yapılamamaktadır!", Succeeded = false };
            }

            Quota quotaToUpdate = _quotaReadRepository.GetWhere(x => x.EventId == eventToUpdate.Id).First();
            if (quotaToUpdate.NumberOfParticipants > updateEvent.MaxParticipantsNumber)
            {
                return new UpdateEventCommandResponse() { Message = "Güncellenmek istenen etkinliğin kontenjanı mevcut katılımcı sayısının altında olamaz!", Succeeded = false };
            }
            quotaToUpdate.MaxParticipantsNumber = updateEvent.MaxParticipantsNumber;
            eventToUpdate.Address = updateEvent.Address;
            _quotaWriteRepository.Update(quotaToUpdate);
            _eventWriteRepository.Update(eventToUpdate);
            await _quotaWriteRepository.SaveChangesAsync();
            await _eventWriteRepository.SaveChangesAsync();
            return new UpdateEventCommandResponse() { Message = "Etkinlik başarıyla güncellenmiştir!", Succeeded = true };
        }
        public async Task<DeleteEventCommandResponse> DeleteAsync(DeleteEventCommandRequest deleteEvent)
        {
            Event eventToDelete = await _eventReadRepository.GetByIdAsync(deleteEvent.Id);
            if (eventToDelete == null)
                return new DeleteEventCommandResponse { Message = "Silinmek istenen etkinlik bulunumadı!", Succeeded = false };
            if (eventToDelete.ApplicationDeadline.Date < DateTime.UtcNow.AddDays(-5))
            {
                return new DeleteEventCommandResponse { Message = "Silinmek istenen etkinliğin başvurulara kapanma tarihine 5 günden az kaldığı için silme işlemi yapılamamaktadır!", Succeeded = false };
            }
            await _eventWriteRepository.RemoveAsync(deleteEvent.Id);
            await _eventWriteRepository.SaveChangesAsync();
            return new DeleteEventCommandResponse() { Message = "Etkinlik başarıyla silinmiştir!", Succeeded = true };
        }

        public async Task<GetAllUnconfirmedEventsQueryResponse> GetAllUnconfirmedEventsAsync(GetAllUnconfirmedEventsQueryRequest events)
        {
            _eventReadRepository.EnableLazyLoading();
            List<Event> unconfirmedEvents = _eventReadRepository.GetWhere(x => x.EventConfirmation == false).ToList();

            return new GetAllUnconfirmedEventsQueryResponse() { Events = _mapper.Map<List<UnconfirmedEventsResponse>>(unconfirmedEvents) };
        }

        public async Task<GetAllConfirmedEventsQueryResponse> GetAllConfirmedEventsAsync(GetAllConfirmedEventsQueryRequest events)
        {
            _eventReadRepository.EnableLazyLoading();
            List<Event> confirmedEvents = _eventReadRepository.GetWhere(x => x.EventConfirmation == true).ToList();

            return new GetAllConfirmedEventsQueryResponse() { Events = _mapper.Map<List<ConfirmedEventsResponse>>(confirmedEvents) };
        }

        public async Task<GetAllEventsByUserQueryResponse> GetAllEventsByUserAsync(GetAllEventsByUserQueryRequest userMail)
        {
            return null;
        }

        public async Task<ConfirmEventCommandResponse> ConfirmEventAsync(ConfirmEventCommandRequest confirmEvent)
        {
            Event eventToUpdate = await _eventReadRepository.GetByIdAsync(confirmEvent.Id);
            if (eventToUpdate == null)
                return new ConfirmEventCommandResponse { Message = "Onaylanmak istenen etkinlik bulunumadı!", Succeeded = false };

            eventToUpdate.EventConfirmation = true;
            _eventWriteRepository.Update(eventToUpdate);
            await _eventWriteRepository.SaveChangesAsync();

            return new ConfirmEventCommandResponse() { Message = "Etkinlik başarıyla onaylanmıştır!", Succeeded = true };
        }

        public async Task<RejectEventCommandResponse> RejectEventAsync(RejectEventCommandRequest rejectEvent)
        {
            Event eventToReject = await _eventReadRepository.GetByIdAsync(rejectEvent.Id);
            if (eventToReject == null)
                return new RejectEventCommandResponse { Message = "Reddedilmek istenen etkinlik bulunumadı!", Succeeded = false };

            await _eventWriteRepository.RemoveAsync(rejectEvent.Id);
            await _eventWriteRepository.SaveChangesAsync();

            return new RejectEventCommandResponse() { Message = "Etkinlik başarıyla reddedilmiştir!", Succeeded = true };
        }

        public async Task<JoinToEventCommandResponse> JoinToEventAsync(JoinToEventCommandRequest joinToEvent)
        {
            _eventReadRepository.EnableLazyLoading();
            _eventWriteRepository.EnableLazyLoading();
            try
            {
                Event eventToJoin = await _eventReadRepository.GetByIdAsync(joinToEvent.EventId);
                if (eventToJoin.Users.Any(x => x.Id == joinToEvent.Id))
                    throw new AlreadyJoinedToEventException();
                AppUser joinEventUser = await _userManager.FindByIdAsync(joinToEvent.Id);
                Quota quotaToUpdate = _quotaReadRepository.GetWhere(x => x.EventId == Guid.Parse(joinToEvent.EventId)).FirstOrDefault();
                if (quotaToUpdate.NumberOfParticipants >= quotaToUpdate.MaxParticipantsNumber)
                    throw new QuotaFullException();
                eventToJoin.Users.Add(joinEventUser);
                quotaToUpdate.NumberOfParticipants += 1;
                _quotaWriteRepository.Update(quotaToUpdate);
                _quotaWriteRepository.SaveChangesAsync();
                _eventWriteRepository.SaveChangesAsync();
            }
            catch
            {
                throw new AlreadyJoinedToEventException();
            }
            return new JoinToEventCommandResponse();
        }

        public async Task<GetCompaniesToBuyTicketQueryResponse> GetCompaniesToBuyTicketAsync(GetCompaniesToBuyTicketQueryRequest request)
        {
            List<AppUser> companies = _userManager.Users.Where(x => x.WebAddressUrl != null).ToList();
            return new GetCompaniesToBuyTicketQueryResponse() { Companies = _mapper.Map<List<GetCompaniesToBuyTicketResponse>>(companies) };
        }
    }
}
