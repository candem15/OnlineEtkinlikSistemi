using AutoMapper;
using OES.API.Application.Dtos;
using OES.API.Application.Dtos.Category;
using OES.API.Application.Dtos.Event;
using OES.API.Application.Dtos.User;
using OES.API.Application.Features.Commands.AppUser.CreateUser;
using OES.API.Application.Features.Commands.AppUser.LoginUser;
using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;
using OES.API.Application.Features.Commands.City.CreateCity;
using OES.API.Application.Features.Commands.City.UpdateCity;
using OES.API.Application.Features.Commands.Event.CreateEvent;
using OES.API.Domain.Entities;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //User mappings
            CreateMap<AppUser, CreateUser>()
                 .ReverseMap();
            CreateMap<AppUser, CreateUserCommandRequest>()
               .ReverseMap();
            CreateMap<AppUser, CreateUser>()
                .ReverseMap();
            CreateMap<CreateUser, CreateUserCommandRequest>()
                .ReverseMap();
            CreateMap<CreateUserCommandResponse, CreateUserResponse>()
                .ReverseMap();

            //City mappings
            CreateMap<CreateCityCommandRequest, City>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName))
                .ReverseMap();
            CreateMap<UpdateCityCommandRequest, City>()
               .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ReverseMap();

            //Auth mappings
            CreateMap<LoginUserCommandResponse, Token>()
                 .ForMember(dest => dest.AccessToken, opt => opt.MapFrom(src => src.Token.AccessToken))
                 .ForMember(dest => dest.Expiration, opt => opt.MapFrom(src => src.Token.Expiration))
                 .ReverseMap();

            //Category mappings
            CreateMap<CreateCategoryCommandRequest, Category>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
                .ReverseMap();
            CreateMap<UpdateCategoryCommandRequest, Category>()
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ReverseMap();
            CreateMap<Category, GetAllCategoriesResponse>()
              .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            //Event mappings
            CreateMap<Event, UnconfirmedEventsResponse>()
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
               .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
               .ForMember(dest => dest.Quota, opt => opt.MapFrom(src => src.Quota.MaxParticipantsNumber))
               .ForMember(dest => dest.EventConfirmation, opt => opt.MapFrom(src => src.EventConfirmation))
               .ForMember(dest => dest.TicketPrice, opt => opt.MapFrom(src => src.Ticket.TicketPrice))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.ApplicationDeadline, opt => opt.MapFrom(src => src.ApplicationDeadline))
               .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.EventDate))
               .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.EventName))
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
