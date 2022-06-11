using Business.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        protected CountryController(CountryService countryService)
        {
            this._countryService = countryService;
        }

        [HttpGet(ApiRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _countryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var country = await _countryService.GetAsync(id);
            return Ok(country);
        }

        [HttpPost(ApiRoutes.Save)]
        public async Task<IActionResult> Save([FromBody] Country country)
        {
            await _countryService.AddAsync(country);
            return CreatedAtAction(nameof(Save), new { id = country.Id }, country);
        }

        [HttpPut(ApiRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Country country)
        {
            var countryObj = await _countryService.GetAsync(id);

            if (countryObj == null)
            {
                return NotFound();
            }

            country.Id = countryObj.Id;

            await _countryService.UpdateAsync(id, country);

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var country = await _countryService.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            await _countryService.DeleteAsync(id);

            return NoContent();
        }
    }
}
