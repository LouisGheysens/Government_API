using Business.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        protected CompanyController(CompanyService companyService)
        {
            this._companyService = companyService;
        }

        [HttpGet(ApiRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Get)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var company = await _companyService.GetAsync(id);
            return Ok(company);
        }

        [HttpPost(ApiRoutes.Save)]
        public async Task<IActionResult> Save([FromBody] Company company)
        {
            await _companyService.AddAsync(company);
            return CreatedAtAction(nameof(Save), new { id = company.Id }, company);
        }

        [HttpPut(ApiRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Company company)
        {
            var companyObj = await _companyService.GetAsync(id);

            if (companyObj == null)
            {
                return NotFound();
            }

            company.Id = companyObj.Id;

            await _companyService.UpdateAsync(id, company);

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var animal = await _companyService.GetAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            await _companyService.DeleteAsync(id);

            return NoContent();
        }
    }
}
