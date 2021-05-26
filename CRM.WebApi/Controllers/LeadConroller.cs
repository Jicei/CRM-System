using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM_System.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_System.Controllers
{
    [EnableCors("CorsApi")]
    [Route("Lead")]
    [ApiController]
    public class LeadConroller : ControllerBase
    {
        private readonly ILeadService leadService;

        public LeadConroller(ILeadService _leadService)
        {
            leadService = _leadService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await leadService.GetAllLead(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await leadService.GetLeadById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] LeadViewModel lead)
        {

            return Ok(await leadService.CreateLead(new LeadDTO
            { 
                Id = id, 
                Name = lead.Name, 
                TypeId = lead.TypeId,
                TelephoneNumber = lead.TelephoneNumber,
                Email = lead.Email,
                Description = lead.Email,
                ActivityId = lead.ActivityId
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] LeadViewModel lead)
        {
            return Ok(await leadService.UpdateFullLead(new LeadDTO
            {
                Id = id,
                Name = lead.Name,
                TypeId = lead.TypeId,
                TelephoneNumber = lead.TelephoneNumber,
                Email = lead.Email,
                Description = lead.Email,
                ActivityId = lead.ActivityId
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] LeadViewModel lead)
        {
            return Ok(await leadService.UpdateLead(new LeadDTO
            {
                Id = id,
                Name = lead.Name,
                TypeId = lead.TypeId,
                TelephoneNumber = lead.TelephoneNumber,
                Email = lead.Email,
                Description = lead.Email,
                ActivityId = lead.ActivityId
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await leadService.DeleteLead(id));
        }
    }
}
