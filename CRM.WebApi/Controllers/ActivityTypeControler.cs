using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM_System.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CRM_System.Controllers
{
    [EnableCors("CorsApi")]
    [Route("ActivityType")]
    [ApiController]
    public class ActivityTypeControler: ControllerBase
    {
        private readonly IActivityTypeService activityTypeService;

        public ActivityTypeControler(IActivityTypeService _activityTypeService)
        {
            activityTypeService = _activityTypeService;
        }
        // GET: <Activity>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject(await activityTypeService.GetAllActivityType(), Formatting.Indented));
        }

        // GET <Activity>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await activityTypeService.GetActivityTypeById(id), Formatting.Indented));
        }

        // POST <Activity>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ActivityTypeViewModel activityType)
        {
            return Ok(await activityTypeService.CreateActivityType( new ActivityTypeDTO
            {
                Id = id,
                Name = activityType.Name
            }));
        }

        // PUT <Activity>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ActivityTypeViewModel activityType)
{
        return Ok(await activityTypeService.UpdateFullActivityType(new ActivityTypeDTO
            {
                Id = id,
                Name = activityType.Name
            }));;
        }

        // PATCH <Activity>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ActivityTypeViewModel activityType)
        {
            return Ok(await activityTypeService.UpdateActivityType(new ActivityTypeDTO
                {
                    Id = id,
                    Name = activityType.Name
                }));
        }

        // DELETE <Activity>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await activityTypeService.DeleteActivityType(id));
        }
    }
}
