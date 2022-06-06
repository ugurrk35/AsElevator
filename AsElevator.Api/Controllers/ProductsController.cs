using AsElevator.Bll.Abstract;
using AsElevator.Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsElevator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto productDto)
        {
            return Ok(await _productService.AddProductAndCategory(productDto));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryId(int id)
         {
            return Ok(await _productService.GetProductAndCategory(id));
        }
        [HttpGet("VeriGetir")]
        public async Task<ActionResult> GetProductWithAttributes(int id)
        {
            return Ok(await _productService.GetProductWithAttributeDto(id));
        }
    }
}
