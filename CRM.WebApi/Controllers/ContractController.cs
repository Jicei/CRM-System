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
    [Route("Contract")]
    [ApiController]
    public class ContractConroller : ControllerBase
    {
        private readonly IContractService contractService;

        public ContractConroller(IContractService _contractService)
        {
            contractService = _contractService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await contractService.GetAllContract(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await contractService.GetContractById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ContractViewModel contract)
        {


            return Ok(await contractService.CreateContract(new ContractDTO
            { 
                Id = id, 
                Name = contract.Name, 
                DateStart = contract.DateStart,
                DateEnd = contract.DateEnd,
                ResponsibleId = contract.ResponsibleId,
                OpportunityId = contract.OpportunityId, 
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ContractViewModel contract)
        {
            return Ok(await contractService.UpdateFullContract(new ContractDTO
            {
                Id = id,
                Name = contract.Name,
                DateStart = contract.DateStart,
                DateEnd = contract.DateEnd,
                ResponsibleId = contract.ResponsibleId,
                OpportunityId = contract.OpportunityId,
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ContractViewModel contract)
        {
            return Ok(await contractService.UpdateContract(new ContractDTO
            {
                Id = id,
                Name = contract.Name,
                DateStart = contract.DateStart,
                DateEnd = contract.DateEnd,
                ResponsibleId = contract.ResponsibleId,
                OpportunityId = contract.OpportunityId,
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await contractService.DeleteContract(id));
        }
    }
}
