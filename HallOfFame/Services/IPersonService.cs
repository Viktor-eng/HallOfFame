using HallOfFame.Dtos.Person;
using HallOfFame.Models;

namespace HallOfFame.Services
{
    public interface IPersonService
    {
        Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons();
        
        Task<ServiceResponse<GetPersonDto>> GetPersonById(int id);

        Task<ServiceResponse<List<GetPersonDto>>> AddPerson (AddPersonDto newPerson);

        Task<ServiceResponse<GetPersonDto>> UpdatePerson (UpdatePersonDto updatedPerson);

        Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int id);
    }
}
