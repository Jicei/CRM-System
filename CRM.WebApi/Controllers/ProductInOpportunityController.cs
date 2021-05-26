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
    [Route("ProductInOpportunity")]
    [ApiController]
    public class ProductInOpportunityController : ControllerBase
    {
        private readonly IProductInOpportunityService productInOpportunityService;

        public ProductInOpportunityController(IProductInOpportunityService _productInOpportunityService)
        {
            productInOpportunityService = _productInOpportunityService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await productInOpportunityService.GetAllProductInOpportunity(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await productInOpportunityService.GetProductInOpportunityById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ProductInOpportunityViewModel productInOpportunity)
        {

            return Ok(await productInOpportunityService.CreateProductInOpportunity(new ProductInOpportunityDTO
            { 
                Id = id,
                OpportunityId = productInOpportunity.OpportunityId,
                ProductId = productInOpportunity.ProductId
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductInOpportunityViewModel productInOpportunity)
        {
            return Ok(await productInOpportunityService.UpdateFullProductInOpportunity(new ProductInOpportunityDTO
            {
                Id = id,
                OpportunityId = productInOpportunity.OpportunityId,
                ProductId = productInOpportunity.ProductId
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ProductInOpportunityViewModel productInOpportunity)
        {
            return Ok(await productInOpportunityService.UpdateProductInOpportunity(new ProductInOpportunityDTO
            {
                Id = id,
                OpportunityId = productInOpportunity.OpportunityId,
                ProductId = productInOpportunity.ProductId
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await productInOpportunityService.DeleteProductInOpportunity(id));
        }
    }
}
