using AutoMapper;
using HallOfFame.Dtos.Person;
using HallOfFame.Models;

namespace HallOfFame.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;


        public PersonService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Person> persons = new List<Person>()
        {
            new Person(),
            new Person {Id = 1, Name = "SuperViktor"}
        };
  

        public async Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDto newPerson)
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            var person = _mapper.Map<Person>(newPerson);
            person.Id = persons.Max(x => x.Id) + 1;
            persons.Add(person);
            serviceResponse.Data = persons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons()
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            serviceResponse.Data = persons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> GetPersonById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();
            var person = persons.FirstOrDefault(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<GetPersonDto>(person);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> UpdatePerson(UpdatePersonDto updatedPerson)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();

            try
            {
                var person = persons.FirstOrDefault(x => x.Id == updatedPerson.Id);
                if (person is null)
                {
                    throw new Exception($"Person with Id '{updatedPerson.Id}' not found.");
                }

                person.Name = updatedPerson.Name;
                person.DisplayName = updatedPerson.DisplayName;
                person.Skills = updatedPerson.Skills;

                serviceResponse.Data = _mapper.Map<GetPersonDto>(person);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();

            try
            {
                var person = persons.FirstOrDefault(x => x.Id == id);
                if (person is null)
                {
                    throw new Exception($"Person with Id '{id}' not found.");
                }

               persons.Remove(person);

                serviceResponse.Data = persons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
