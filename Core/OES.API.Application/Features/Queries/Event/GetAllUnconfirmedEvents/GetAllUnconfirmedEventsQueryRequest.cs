using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Queries.Event.GetAllUnconfirmedEvents
{
    public class GetAllUnconfirmedEventsQueryRequest : IRequest<GetAllUnconfirmedEventsQueryResponse>
    {
    }
}
