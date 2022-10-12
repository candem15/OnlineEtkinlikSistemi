using OES.API.Application.Dtos.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Queries.Event.GetEventsByOrganizer
{
    public class GetEventsByOrganizerQueryResponse
    {
        public List<GetEventsByOrganizerResponse> Events { get; set; }
    }
}
