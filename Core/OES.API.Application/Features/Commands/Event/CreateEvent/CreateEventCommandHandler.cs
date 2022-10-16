﻿using AutoMapper;
using MediatR;
using OES.API.Application.Abstractions.Services;

namespace OES.API.Application.Features.Commands.Event.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, CreateEventCommandResponse>
    {
        private IEventService _eventService;
        private IMapper _mapper;

        public CreateEventCommandHandler(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<CreateEventCommandResponse> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            CreateEventCommandResponse response = await _eventService.CreateAsync(request);

            return response;
        }
    }
}
