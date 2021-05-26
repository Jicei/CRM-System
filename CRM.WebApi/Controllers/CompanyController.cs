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
    [Route("Company")]
    [ApiController]
    public class CompanyConroller : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyConroller(ICompanyService _companyService)
        {
            companyService = _companyService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await companyService.GetAllCompany(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await companyService.GetCompanyById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] CompanyViewModel company)
        {


            return Ok(await companyService.CreateCompany(new CompanyDTO
            { 
                Id = id, 
                Name = company.Name, 
                Telephone = company.Telephone,
                Email = company.Email,
                ResponsibleId = company.ResponsibleId,
                CountryId = company.CountryId, 
                CityId = company.CityId,
                LeadId = company.LeadId
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CompanyViewModel company)
        {
            return Ok(await companyService.UpdateFullCompany(new CompanyDTO
            {
                Id = id,
                Name = company.Name,
                Telephone = company.Telephone,
                Email = company.Email,
                ResponsibleId = company.ResponsibleId,
                CountryId = company.CountryId,
                CityId = company.CityId,
                LeadId = company.LeadId
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] CompanyViewModel company)
        {
            return Ok(await companyService.UpdateCompany(new CompanyDTO
            {
                Id = id,
                Name = company.Name,
                Telephone = company.Telephone,
                Email = company.Email,
                ResponsibleId = company.ResponsibleId,
                CountryId = company.CountryId,
                CityId = company.CityId,
                LeadId = company.LeadId
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await companyService.DeleteCompany(id));
        }
    }
}
