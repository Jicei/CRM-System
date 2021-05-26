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
    [Route("EmployeeInRole")]
    [ApiController]
    public class EmployeeInRoleController : ControllerBase
    {
        private readonly IEmployeeInRoleService employeeInRoleService;

        public EmployeeInRoleController(IEmployeeInRoleService _employeeInRoleService)
        {
            employeeInRoleService = _employeeInRoleService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await employeeInRoleService.GetAllEmployeeInRole(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await employeeInRoleService.GetEmployeeInRoleById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] EmployeeInRoleViewModel employeeInRole)
        {


            return Ok(await employeeInRoleService.CreateEmployeeInRole(new EmployeeInRoleDTO
            { 
                Id = id, 
                EmployeeId = employeeInRole.EmployeeId, 
                RoleId = employeeInRole.RoleId,
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EmployeeInRoleViewModel employeeInRole)
        {
            return Ok(await employeeInRoleService.UpdateFullEmployeeInRole(new EmployeeInRoleDTO
            {
                Id = id,
                EmployeeId = employeeInRole.EmployeeId,
                RoleId = employeeInRole.RoleId,
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] EmployeeInRoleViewModel employeeInRole)
        {
            return Ok(await employeeInRoleService.UpdateEmployeeInRole(new EmployeeInRoleDTO
            {
                Id = id,
                EmployeeId = employeeInRole.EmployeeId,
                RoleId = employeeInRole.RoleId,
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await employeeInRoleService.DeleteEmployeeInRole(id));
        }
    }
}
