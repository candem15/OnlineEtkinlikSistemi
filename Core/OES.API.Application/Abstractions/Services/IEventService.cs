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
using OES.API.Application.Features.Queries.Event.GetEventsByOrganizer;
using OES.API.Application.Features.Queries.Event.GetEventsByUser;
using OES.API.Application.Features.Queries.Event.GetEventsInXml;
using OES.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task<CreateEventCommandResponse> CreateAsync(CreateEventCommandRequest createEvent);
        Task<UpdateEventCommandResponse> UpdateAsync(UpdateEventCommandRequest updateEvent);
        Task<DeleteEventCommandResponse> DeleteAsync(DeleteEventCommandRequest deleteEvent);
        Task<ConfirmEventCommandResponse> ConfirmEventAsync(ConfirmEventCommandRequest confirmEvent);
        Task<RejectEventCommandResponse> RejectEventAsync(RejectEventCommandRequest rejectEvent);
        Task<GetAllUnconfirmedEventsQueryResponse> GetAllUnconfirmedEventsAsync(GetAllUnconfirmedEventsQueryRequest events);
        Task<GetAllConfirmedEventsQueryResponse> GetAllConfirmedEventsAsync(GetAllConfirmedEventsQueryRequest events);
        //Task<GetAllEventsByUserQueryResponse> GetAllEventsByUserAsync(GetAllEventsByUserQueryRequest userMail);
        Task<JoinToEventCommandResponse> JoinToEventAsync(JoinToEventCommandRequest joinToEvent);
        Task<GetCompaniesToBuyTicketQueryResponse> GetCompaniesToBuyTicketAsync(GetCompaniesToBuyTicketQueryRequest request);
        Task<GetEventsByOrganizerQueryResponse> GetEventsByOrganizerAsync(GetEventsByOrganizerQueryRequest request);
        Task<GetEventsForCompaniesQueryResponse> GetEventsInXmlAsync(GetEventsForCompaniesQueryRequest request);
        Task<GetEventsByUserQueryResponse> GetEventsByUserAsync(GetEventsByUserQueryRequest request);
    }
}