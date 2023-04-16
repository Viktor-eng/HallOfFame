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
            CreateMap<Skill, GetSkillDto>(); 
            CreateMap<AddPersonDto, Person>();
            CreateMap<AddSkillDto, Skill>();
            CreateMap<UpdatePersonDto, Person>();
            CreateMap<Skill, UpdateSkillDto>().ReverseMap(); 
        }
    }
}
