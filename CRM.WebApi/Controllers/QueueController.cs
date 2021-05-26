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
    [Route("Queue")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService queueService;

        public QueueController(IQueueService _queueService)
        {
            queueService = _queueService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await queueService.GetAllQueue(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await queueService.GetQueueById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] QueueViewModel queue)
        {

            return Ok(await queueService.CreateQueue(new QueueDTO
            { 
                Id = id,
                TelephoneNumber = queue.TelephoneNumber,
                DateTimeStartCall = queue.DateTimeStartCall,
                TimeWait = queue.TimeWait,
                DateStartAnswer = queue.DateStartAnswer,
                DateEndAnswer = queue.DateEndAnswer,
                ResponsibleId = queue.ResponsibleId,
                Description = queue.Description
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] QueueViewModel queue)
        {
            return Ok(await queueService.UpdateFullQueue(new QueueDTO
            {
                Id = id,
                TelephoneNumber = queue.TelephoneNumber,
                DateTimeStartCall = queue.DateTimeStartCall,
                TimeWait = queue.TimeWait,
                DateStartAnswer = queue.DateStartAnswer,
                DateEndAnswer = queue.DateEndAnswer,
                ResponsibleId = queue.ResponsibleId,
                Description = queue.Description
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] QueueViewModel queue)
        {
            return Ok(await queueService.UpdateQueue(new QueueDTO
            {
                Id = id,
                TelephoneNumber = queue.TelephoneNumber,
                DateTimeStartCall = queue.DateTimeStartCall,
                TimeWait = queue.TimeWait,
                DateStartAnswer = queue.DateStartAnswer,
                DateEndAnswer = queue.DateEndAnswer,
                ResponsibleId = queue.ResponsibleId,
                Description = queue.Description
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await queueService.DeleteQueue(id));
        }
    }
}
