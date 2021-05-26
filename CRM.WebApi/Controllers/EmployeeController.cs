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
    [Route("Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await employeeService.GetAllEmployee(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await employeeService.GetEmployeeById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] EmployeeViewModel employee)
        {

            return Ok(await employeeService.CreateEmployee(new EmployeeDTO
            { 
                Id = id, 
                Name = employee.Name, 
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                Email = employee.Email,
                Telephone = employee.Telephone
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EmployeeViewModel employee)
        {
            return Ok(await employeeService.UpdateFullEmployee(new EmployeeDTO
            {
                Id = id,
                Name = employee.Name,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                Email = employee.Email,
                Telephone = employee.Telephone
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] EmployeeViewModel employee)
        {
            return Ok(await employeeService.UpdateEmployee(new EmployeeDTO
            {
                Id = id,
                Name = employee.Name,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                Email = employee.Email,
                Telephone = employee.Telephone
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await employeeService.DeleteEmployee(id));
        }
    }
}
