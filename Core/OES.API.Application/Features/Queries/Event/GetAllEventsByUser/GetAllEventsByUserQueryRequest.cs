using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Queries.Event.GetAllEventsByUser
{
    public class GetAllEventsByUserQueryRequest:IRequest<GetAllEventsByUserQueryResponse>
    {
        public string? Email { get; set; }
    }
}
