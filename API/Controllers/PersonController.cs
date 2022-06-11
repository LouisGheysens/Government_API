using Business.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class PersonController: ControllerBase
    {

        private readonly PersonService _personService;

        protected PersonController(PersonService personService)
        {
            this._personService = personService;
        }

        [HttpGet(ApiRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _personService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var person = await _personService.GetAsync(id);
            return Ok(person);
        }

        [HttpPost(ApiRoutes.Save)]
        public async Task<IActionResult> Save([FromBody] Person person)
        {
            await _personService.AddAsync(person);
            return CreatedAtAction(nameof(Save), new { id =  person.Id }, person);
        }

        [HttpPut(ApiRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Person person)
        {
            var personObj = await _personService.GetAsync(id);

            if(personObj == null)
            {
                return NotFound();
            }

            person.Id = personObj.Id;

            await _personService.UpdateAsync(id, person);

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var person = await _personService.GetAsync(id);

            if(person == null)
            {
                return NotFound();
            }

            await _personService.DeleteAsync(id);

            return NoContent();
        }
    }
}
