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
    [Route("Contact")]
    [ApiController]
    public class ContactConroller : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactConroller(IContactService _contactService)
        {
            contactService = _contactService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await contactService.GetAllContact(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await contactService.GetContactById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ContactViewModel contact)
        {
            return Ok(await contactService.CreateContact(new ContactDTO
            { 
                Id = id, 
                Name = contact.Name, 
                Surname = contact.Surname,
                Patronymic = contact.Patronymic,
                Telephone = contact.Telephone,
                Description = contact.Description, 
                CompanyId = contact.CompanyId,
                CountryId = contact.CountryId,
                ResponsibleId = contact.ResponsibleId,
                CityId = contact.CityId
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ContactViewModel contact)
        {
            return Ok(await contactService.UpdateFullContact(new ContactDTO
            {
                Id = id,
                Name = contact.Name,
                Surname = contact.Surname,
                Patronymic = contact.Patronymic,
                Telephone = contact.Telephone,
                Description = contact.Description,
                CompanyId = contact.CompanyId,
                CountryId = contact.CountryId,
                ResponsibleId = contact.ResponsibleId,
                CityId = contact.CityId
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ContactViewModel contact)
        {
            return Ok(await contactService.UpdateContact(new ContactDTO
            {
                Id = id,
                Name = contact.Name,
                Surname = contact.Surname,
                Patronymic = contact.Patronymic,
                Telephone = contact.Telephone,
                Description = contact.Description,
                CompanyId = contact.CompanyId,
                CountryId = contact.CountryId,
                ResponsibleId = contact.ResponsibleId,
                CityId = contact.CityId
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await contactService.DeleteContact(id));
        }
    }
}
