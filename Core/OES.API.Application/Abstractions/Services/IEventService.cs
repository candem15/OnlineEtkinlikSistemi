using OES.API.Application.Features.Commands.Event.CreateEvent;
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
    }
}
