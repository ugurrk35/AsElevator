using AsElevator.Bll.Abstract;
using AsElevator.Entity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsElevator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories([FromQuery] string searchTerm)
        {
            return Ok(await _categoryService.GetCategories(searchTerm));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryId(int id)
        {
            return Ok(await _categoryService.GetCategoriesID(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto)
        {
            return Ok(await _categoryService.Post(categoryDto));
        }
    }
}
