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
    [Route("Client")]
    [ApiController]
    public class ClientConroller: ControllerBase
    {
        private readonly IClientService clientService;

        public ClientConroller(IClientService _clientService)
        {
            clientService = _clientService;
        }
        // GET: <Activity>
        [HttpGet("ClasterClient")]
        public IActionResult NeuronKohonena(/*[FromBody] DateLimitViewModel dateLimit*/)
        {
            return Ok(JsonConvert.SerializeObject(clientService.NeuronKohonena(/*dateLimit.DateFrom, dateLimit.DateTo*/), Formatting.Indented));
        }

        // GET <Activity>/5
        [HttpGet("RFMClient")]
        public IActionResult RFMAnalysis(/*[FromBody] DateLimitViewModel dateLimit*/)
        {
            return Ok(JsonConvert.SerializeObject(clientService.ContactRFMAnalysis(/*dateLimit.DateFrom, dateLimit.DateTo*/), Formatting.Indented));
        }
    }
}
