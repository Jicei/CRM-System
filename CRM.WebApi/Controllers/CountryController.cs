using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM_System.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_System.Controllers
{
    [EnableCors("CorsApi")]
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }
        // GET: <CountryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await countryService.GetAllCountry(), Formatting.Indented));
        }

        // GET <CountryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await countryService.GetCountryById(id), Formatting.Indented));
        }

        // POST <CountryController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] CountryViewModel country)
        {
            return Ok(await countryService.CreateCountry(new CountryDTO { Id = id, Name = country.Name}));
        }

        // PUT <CountryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CountryViewModel country)
        {
            return Ok(await countryService.UpdateFullCountry(new CountryDTO { Id = id, Name = country.Name }));
        }

        // PATCH <CountryController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] CountryViewModel country)
        {
            return Ok(await countryService.UpdateCountry(new CountryDTO { Id = id, Name = country.Name }));
        }

        // DELETE <CountryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await countryService.DeleteCountry(id));
        }
    }
}
