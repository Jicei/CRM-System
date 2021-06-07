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
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        // GET: <CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(JsonConvert.SerializeObject( await productService.GetAllProduct(), Formatting.Indented));
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(JsonConvert.SerializeObject(await productService.GetProductById(id), Formatting.Indented));
        }

        // POST <CityController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] ProductViewModel product)
        {

            return Ok(await productService.CreateProduct(new ProductDTO
            { 
                Id = id, 
                Name = product.Name, 
                Price = product.Price,
                Description = product.Description,
                Remains = product.Remains,
                ResponsibleId = product.ResponsibleId,
            }));
        }

        // PUT <CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductViewModel product)
        {
            return Ok(await productService.UpdateFullProduct(new ProductDTO
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Remains = product.Remains,
                ResponsibleId = product.ResponsibleId,
            }));
        }

        // PATCH <CityController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] ProductViewModel product)
        {
            return Ok(await productService.UpdateProduct(new ProductDTO
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Remains = product.Remains,
                ResponsibleId = product.ResponsibleId,
            }));
        }

        // DELETE <CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await productService.DeleteProduct(id));
        }

        [HttpGet("ABCFMR")]
        public IActionResult GetABCFMR()
        {
            return Ok(JsonConvert.SerializeObject( productService.ProductABCFMRanalysis(), Formatting.Indented));
        }
    }
}
