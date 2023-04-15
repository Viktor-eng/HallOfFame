using AutoMapper;
using HallOfFame.Dtos.Person;
using HallOfFame.Models;

namespace HallOfFame
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, GetPersonDto>();
            CreateMap<AddPersonDto, Person>();
        }
    }
}
