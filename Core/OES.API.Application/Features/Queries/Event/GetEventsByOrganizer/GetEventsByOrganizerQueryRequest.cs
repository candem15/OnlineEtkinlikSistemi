using MediatR;

namespace OES.API.Application.Features.Queries.Event.GetEventsByOrganizer
{
    public class GetEventsByOrganizerQueryRequest : IRequest<GetEventsByOrganizerQueryResponse>
    {
        public string? Id { get; set; }
    }
}