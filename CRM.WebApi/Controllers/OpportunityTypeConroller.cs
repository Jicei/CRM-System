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
    [Route("OpportunityType")]
    [ApiController]
    public class OpportunityTypeConroller : ControllerBase
    {
        private readonly IOpportunityTypeService opportunityTypeService;

        public OpportunityTypeConroller(IOpportunityTypeService _opportunityTypeService)
        {
            opportunityTypeService = _opportunityTypeService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await opportunityTypeService.GetAllOpportunityType(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await opportunityTypeService.GetOpportunityTypeById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] OpportunityTypeViewModel opportunity)
        {

            return Ok(await opportunityTypeService.CreateOpportunityType(new OpportunityTypeDTO
            { 
                Id = id, 
                Name = opportunity.Name
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OpportunityTypeViewModel opportunity)
        {
            return Ok(await opportunityTypeService.UpdateFullOpportunityType(new OpportunityTypeDTO
            {
                Id = id,
                Name = opportunity.Name
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] OpportunityTypeViewModel opportunity)
        {
            return Ok(await opportunityTypeService.UpdateOpportunityType(new OpportunityTypeDTO
            {
                Id = id,
                Name = opportunity.Name
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await opportunityTypeService.DeleteOpportunityType(id));
        }
    }
}
