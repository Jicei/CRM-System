using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CRM_System.Controllers
{
    [EnableCors("CorsApi")]
    [Route("ActivityManagerType")]
    [ApiController]
    public class ActivityManagerTypeControler: ControllerBase
    {
        private readonly IActivityManagerTypeService activityManagerTypeService;

        public ActivityManagerTypeControler(IActivityManagerTypeService _activityManagerTypeControler)
        {
            activityManagerTypeService = _activityManagerTypeControler;
        }
        // GET: <ActivityManager>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject(await activityManagerTypeService.GetAllActivityManagerType(), Formatting.Indented));
        }

        // GET <ActivityManager>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await activityManagerTypeService.GetActivityManagerTypeById(id), Formatting.Indented));
        }

        // POST <ActivityManager>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ActivityManagerTypeViewModel activityManagerType)
        {
            return Ok(await activityManagerTypeService.CreateActivityManagerType( new ActivityManagerTypeDTO
            {
                Id = id,
                Name = activityManagerType.Name,
            }));
        }

        // PUT <ActivityManager>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ActivityManagerTypeViewModel activityManager)
{
        return Ok(await activityManagerTypeService.UpdateFullActivityManagerType(new ActivityManagerTypeDTO
            {
                Id = id,
                Name = activityManager.Name,
            }));
        }

        // PATCH <ActivityManager>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ActivityManagerTypeViewModel activityManagerType)
        {
            return Ok(await activityManagerTypeService.UpdateActivityManagerType(new ActivityManagerTypeDTO
                {
                    Id = id,
                    Name = activityManagerType.Name,
                }));
        }

        // DELETE <ActivityManager>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await activityManagerTypeService.DeleteActivityManagerType(id));
        }
    }
}
