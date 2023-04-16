using HallOfFame.Dtos.Person;
using HallOfFame.Models;

namespace HallOfFame.Services
{
    public interface IPersonService
    {
        Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons();
        
        Task<ServiceResponse<GetPersonDto>> GetPersonById(int id);

        Task<ServiceResponse<int>> AddPerson (AddPersonDto newPerson);

        Task<ServiceResponse<GetPersonDto>> UpdatePerson (UpdatePersonDto updatedPerson);

        Task DeletePerson(int id);
    }
}
