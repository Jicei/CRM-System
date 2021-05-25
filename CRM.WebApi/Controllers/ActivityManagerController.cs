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
    [Route("ActivityManager")]
    [ApiController]
    public class ActivityManagerControler: ControllerBase
    {
        private readonly IActivityManagerService activityManagerService;

        public ActivityManagerControler(IActivityManagerService _activityManagerControler)
        {
            activityManagerService = _activityManagerControler;
        }
        // GET: <ActivityManager>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject(await activityManagerService.GetAllActivityManager(), Formatting.Indented));
        }

        // GET <ActivityManager>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await activityManagerService.GetActivityManagerById(id), Formatting.Indented));
        }

        // POST <ActivityManager>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ActivityManagerViewModel activityManager)
        {
            return Ok(await activityManagerService.CreateActivityManager( new ActivityManagerDTO
            {
                Id = id,
                Name = activityManager.Name,
                ActivityManagerTypeId = activityManager.ActivityManagerTypeId,
                ContactId = activityManager.ContactId,
                LeadId = activityManager.LeadId,
                ResponsibleId = activityManager.ResponsibleId
            }));
        }

        // PUT <ActivityManager>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ActivityManagerViewModel activityManager)
{
        return Ok(await activityManagerService.UpdateFullActivityManager(new ActivityManagerDTO
            {
                Id = id,
                Name = activityManager.Name,
                ActivityManagerTypeId = activityManager.ActivityManagerTypeId,
                ContactId = activityManager.ContactId,
                LeadId = activityManager.LeadId,
                ResponsibleId = activityManager.ResponsibleId
            }));
        }

        // PATCH <ActivityManager>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ActivityManagerViewModel activityManager)
        {
            return Ok(await activityManagerService.UpdateActivityManager(new ActivityManagerDTO
                {
                    Id = id,
                    Name = activityManager.Name,
                    ActivityManagerTypeId = activityManager.ActivityManagerTypeId,
                    ContactId = activityManager.ContactId,
                    LeadId = activityManager.LeadId,
                    ResponsibleId = activityManager.ResponsibleId
                }));
        }

        // DELETE <ActivityManager>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await activityManagerService.DeleteActivityManager(id));
        }
    }
}
