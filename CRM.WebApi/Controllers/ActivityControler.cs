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
    [Route("Activity")]
    [ApiController]
    public class ActivityControler: ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivityControler(IActivityService _activityService)
        {
            activityService = _activityService;
        }
        // GET: <Activity>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject(await activityService.GetAllActivity(), Formatting.Indented));
        }

        // GET <Activity>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await activityService.GetActivityById(id), Formatting.Indented));
        }

        // POST <Activity>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ActivityViewModel activity)
        {
            return Ok(await activityService.CreateActivity( new ActivityDTO
            {
                Id = id,
                CreatedOn = activity.CreatedOn,
                Name = activity.Name,
                DateStart = activity.DateStart,
                DateEnd = activity.DateEnd,
                TypeActivityId = activity.TypeActivityId,
                ResponsibleId = activity.ResponsibleId
            }));
        }

        // PUT <Activity>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ActivityViewModel activity)
{
        return Ok(await activityService.UpdateFullActivity(new ActivityDTO
            {
                Id = id,
                CreatedOn = activity.CreatedOn,
                Name = activity.Name,
                DateStart = activity.DateStart,
                DateEnd = activity.DateEnd,
                TypeActivityId = activity.TypeActivityId,
                ResponsibleId = activity.ResponsibleId
            }));
        }

        // PATCH <Activity>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ActivityViewModel activity)
        {
            return Ok(await activityService.UpdateActivity(new ActivityDTO
                {
                    Id = id,
                    CreatedOn = activity.CreatedOn,
                    Name = activity.Name,
                    DateStart = activity.DateStart,
                    DateEnd = activity.DateEnd,
                    TypeActivityId = activity.TypeActivityId,
                    ResponsibleId = activity.ResponsibleId
                }));
        }

        // DELETE <Activity>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await activityService.DeleteActivity(id));
        }
        [HttpGet("AbcXyz")]
        public IActionResult GetAbcXyz()
        {
            return Ok(JsonConvert.SerializeObject(activityService.ActivityABCXYZanalysis(), Formatting.Indented));
        }
    }
}
