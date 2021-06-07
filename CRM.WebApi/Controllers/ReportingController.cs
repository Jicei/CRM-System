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
    [Route("Report")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportingController(IReportService _reportService)
        {
            reportService = _reportService;
        }
        // GET: <CityController>
        [HttpGet("LinePrediction")]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await reportService.LinePrediction(), Formatting.Indented));
        }
    }
}
