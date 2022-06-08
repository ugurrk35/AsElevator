using AsElevator.Bll.Abstract;
using AsElevator.Dal.Abstract;
using AsElevator.Entity.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsElevator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, IProductRepository productRepository, IMapper mapper)
        {
            _productService = productService;
            _productRepository = productRepository; 
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto productDto)
        {
            return Ok(await _productService.AddProductAndCategory(productDto));
        }
        [HttpGet("ProductWithCategory")]
        public async Task<ActionResult> GetCategoryId(int id)
         {
            return Ok(await _productService.GetProductAndCategory(id));
        }
        [HttpGet("ProductWithAttribute")]
        public async Task<ActionResult> GetProductWithAttributes(int id)
        {
            return Ok(await _productService.GetProductWithAttributeDto(id));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id,[FromBody] UpdateProductDto item)
        {

            return Ok(await _productService.UpdateProduct(item, id));
        
          
        }
    }
}
