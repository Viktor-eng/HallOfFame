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


        public async Task<ServiceResponse<int>> AddPerson(AddPersonDto newPerson)
        {
            var serviceResponse = new ServiceResponse<int>();
            var person = _mapper.Map<Person>(newPerson);
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            serviceResponse.Data = person.Id;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons()
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();

            var dbPersons = await _context.Persons
                .Include(p => p.Skills)
                .ToListAsync();

            serviceResponse.Data = dbPersons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> GetPersonById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();

            var dbPerson = await _context.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);

            serviceResponse.Data = _mapper.Map<GetPersonDto>(dbPerson);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> UpdatePerson(UpdatePersonDto updatedPerson)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();

            try
            {
                var dbPerson = await _context.Persons
                    .Include(p => p.Skills)
                    .FirstOrDefaultAsync(x => x.Id == updatedPerson.Id);

                if (dbPerson is null)
                {
                    serviceResponse.Data = null;
                    return serviceResponse;
                }

                dbPerson.Name = updatedPerson.Name;
                dbPerson.DisplayName = updatedPerson.DisplayName;

                foreach (var skillUpdateDto in updatedPerson.Skills)
                {
                    var dbSkill = dbPerson.Skills.First(x => x.Id == skillUpdateDto.Id);
                    dbSkill.Name = skillUpdateDto.Name;
                    dbSkill.Level = skillUpdateDto.Level;

                    if(!dbPerson.Skills.Any(s => s.Id == dbSkill.Id))
                    {
                        dbPerson.Skills.Add(dbSkill);
                    }
                }



                //var newSkills = updatedPerson.Skills.Where(x => x.Id == 0).Select(s => _mapper.Map<Skill>(s)).ToList();
                //dbPerson.Skills.AddRange(newSkills);

                //var changedSkills = updatedPerson.Skills.Where(x => x.Id != 0).Select(s => _mapper.Map<Skill>(s)).ToList();



                //foreach (var changed in changedSkills)
                //{
                //    var dbSkill = dbPerson.Skills.First(x => x.Id == changed.Id);
                //    dbSkill.Name = changed.Name;
                //    dbSkill.Level = changed.Level;
                //}

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetPersonDto>(dbPerson);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task DeletePerson(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();

            var dbPerson = await _context.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dbPerson is null)
            {
                throw new Exception($"Person with Id '{id}' not found.");
            }
            _context.Persons.Remove(dbPerson);

            await _context.SaveChangesAsync();
        }
    }
}
