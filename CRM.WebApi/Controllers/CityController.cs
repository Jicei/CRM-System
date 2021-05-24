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
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;

        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }
        // GET: api/<CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await cityService.GetAllCity(), Formatting.Indented));
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await cityService.GetCityById(id), Formatting.Indented));
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] CityViewModel city)
        {
            return Ok(await cityService.CreateCity(new CityDTO { Id = id, Name = city.Name, CountryId = city.CountryId }));
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CityViewModel city)
        {
            return Ok(await cityService.UpdateCity(new CityDTO { Id = id, Name = city.Name, CountryId = city.CountryId }));
        }

        // PATCH api/<CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] CityViewModel city)
        {
            return Ok(await cityService.UpdateFullCity(new CityDTO { Id = id, Name = city.Name, CountryId = city.CountryId }));
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await cityService.DeleteCity(id));
        }
    }
}
