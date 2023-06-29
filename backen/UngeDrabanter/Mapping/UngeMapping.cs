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
            CreateMap<SessionDto, Session>();
            CreateMap<Session, SessionDto>();
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();
        }
    }
}
