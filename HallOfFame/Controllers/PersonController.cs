using HallOfFame.Dtos.Person;
using HallOfFame.Models;
using HallOfFame.Services;
using Microsoft.AspNetCore.Mvc;

namespace HallOfFame.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;


        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet("persons")]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> GetAllPersons()
        {
            return Ok(await _personService.GetAllPersons());
        }

        [HttpGet("person/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> GetPersonById(int id)
        {
            return Ok(await _personService.GetPersonById(id));
        }

        [HttpPost("person")]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> AddPerson(AddPersonDto newPerson)
        {
            return Ok(await _personService.AddPerson(newPerson));
        } 
        
        [HttpPut("person")]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> UpdatePerson(UpdatePersonDto updatedPerson)
        {
            var response = await _personService.UpdatePerson(updatedPerson);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("person/{id}")]
        public async Task<ActionResult<ServiceResponse<GetPersonDto>>> DeletePerson(int id)
        {
            var response = await _personService.DeletePerson(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
