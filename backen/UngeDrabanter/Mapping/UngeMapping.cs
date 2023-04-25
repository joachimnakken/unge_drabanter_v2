using AutoMapper;
using UngeDrabanter.DtoModels;
using UngeDrabanter.Models;

namespace UngeDrabanter.Mapping
{
    public class UngeMapping : Profile
    {
        public UngeMapping()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
        }
    }
}
