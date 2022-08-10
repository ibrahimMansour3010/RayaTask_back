using Application.Contracts.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _personService.GetAll();
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _personService.Get(Id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpPost("ManagePerson")]
        public async Task<IActionResult> ManagePerson(PersonDTO person)
        {
            var response = await _personService.ManagePerson(person);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _personService.Delete(Id);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
