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
    [Route("Opportunity")]
    [ApiController]
    public class OpportunityConroller : ControllerBase
    {
        private readonly IOpportunityService opportunityService;

        public OpportunityConroller(IOpportunityService _opportunityService)
        {
            opportunityService = _opportunityService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await opportunityService.GetAllOpportunity(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await opportunityService.GetOpportunityById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] OpportunityViewModel opportunity)
        {

            return Ok(await opportunityService.CreateOpportunity(new OpportunityDTO
            { 
                Id = id, 
                DateStart = opportunity.DateStart, 
                DateEnd = opportunity.DateEnd,
                TimeWait = opportunity.TimeWait,
                Description = opportunity.Description,
                Price = opportunity.Price,
                Discount = opportunity.Discount,
                ContactId = opportunity.ContactId,
                CompanyId = opportunity.CompanyId,
                ResponsibleId = opportunity.ResponsibleId,
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OpportunityViewModel opportunity)
        {
            return Ok(await opportunityService.UpdateFullOpportunity(new OpportunityDTO
            {
                Id = id,
                DateStart = opportunity.DateStart,
                DateEnd = opportunity.DateEnd,
                TimeWait = opportunity.TimeWait,
                Description = opportunity.Description,
                Price = opportunity.Price,
                Discount = opportunity.Discount,
                ContactId = opportunity.ContactId,
                CompanyId = opportunity.CompanyId,
                ResponsibleId = opportunity.ResponsibleId,
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] OpportunityViewModel opportunity)
        {
            return Ok(await opportunityService.UpdateOpportunity(new OpportunityDTO
            {
                Id = id,
                DateStart = opportunity.DateStart,
                DateEnd = opportunity.DateEnd,
                TimeWait = opportunity.TimeWait,
                Description = opportunity.Description,
                Price = opportunity.Price,
                Discount = opportunity.Discount,
                ContactId = opportunity.ContactId,
                CompanyId = opportunity.CompanyId,
                ResponsibleId = opportunity.ResponsibleId,
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await opportunityService.DeleteOpportunity(id));
        }
    }
}
