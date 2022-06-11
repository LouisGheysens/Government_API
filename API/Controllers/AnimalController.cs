using Business.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;

        protected AnimalController(AnimalService animalService)
        {
            this._animalService = animalService;
        }

        [HttpGet(ApiRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _animalService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var animal = await _animalService.GetAsync(id);
            return Ok(animal);
        }

        [HttpPost(ApiRoutes.Save)]
        public async Task<IActionResult> Save([FromBody] Animal animal)
        {
            await _animalService.AddAsync(animal);
            return CreatedAtAction(nameof(Save), new {id = animal.Id}, animal);
        }

        [HttpPut(ApiRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Animal animal)
        {
            var animalObj = await _animalService.GetAsync(id);

            if(animalObj == null)
            {
                return NotFound();
            }

            animal.Id = animalObj.Id;

            await _animalService.UpdateAsync(id, animal);

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var animal = await _animalService.GetAsync(id);

            if(animal == null)
            {
                return NotFound();
            }

            await _animalService.DeleteAsync(id);

            return NoContent();
        }
    }
}
