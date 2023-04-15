using AutoMapper;
using HallOfFame.Data;
using HallOfFame.Dtos.Person;
using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public PersonService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
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
            persons.Add(_mapper.Map<Person>(newPerson));
            serviceResponse.Data = await _context.Persons.Select(c => _mapper.Map<GetPersonDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons()
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            var dbPersons = await _context.Persons.ToListAsync();
            serviceResponse.Data = dbPersons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> GetPersonById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();
            var dbPerson = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<GetPersonDto>(dbPerson);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> UpdatePerson(UpdatePersonDto updatedPerson)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();

            try
            {
                var dbPerson = await _context.Persons.FirstOrDefaultAsync(x => x.Id == updatedPerson.Id);
                if (dbPerson is null)
                {
                    throw new Exception($"Person with Id '{updatedPerson.Id}' not found.");
                }

                dbPerson.Name = updatedPerson.Name;
                dbPerson.DisplayName = updatedPerson.DisplayName;
                dbPerson.Skills = updatedPerson.Skills;

                serviceResponse.Data = _mapper.Map<GetPersonDto>(dbPerson);
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
                var dbPerson = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
                if (dbPerson is null)
                {
                    throw new Exception($"Person with Id '{id}' not found.");
                }

               persons.Remove(dbPerson);

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
