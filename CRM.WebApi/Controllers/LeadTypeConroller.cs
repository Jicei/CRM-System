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
    [Route("Company")]
    [ApiController]
    public class LeadTypeConroller : ControllerBase
    {
        private readonly ILeadTypeService leadTypeService;

        public LeadTypeConroller(ILeadTypeService _leadTypeService)
        {
            leadTypeService = _leadTypeService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await leadTypeService.GetAllLeadType(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await leadTypeService.GetLeadTypeById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] LeadViewModel lead)
        {

            return Ok(await leadTypeService.CreateLeadType(new LeadTypeDTO
            { 
                Id = id, 
                Name = lead.Name
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] LeadViewModel lead)
        {
            return Ok(await leadTypeService.UpdateFullLeadType(new LeadTypeDTO
            {
                Id = id,
                Name = lead.Name
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] LeadViewModel lead)
        {
            return Ok(await leadTypeService.UpdateLeadType(new LeadTypeDTO
            {
                Id = id,
                Name = lead.Name
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await leadTypeService.DeleteLeadType(id));
        }
    }
}
