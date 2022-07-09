using Microsoft.AspNetCore.Mvc;
using FoodsOnline.API.DTOs.Data;
using FoodsOnline.API.Services.Contracts;

namespace FoodsOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Retorna todas categorias.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoryDto = await _categoryService.GetCategory();

            if (categoryDto == null) return NotFound("Categoria não encontrada");

            return Ok(categoryDto);
        }

        /// <summary>
        /// Retorna todas categorias e seus produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategorysProducts()
        {
            var categoryDto = await _categoryService.GetCategorysProducts();

            if (categoryDto == null) return NotFound("Categoria não encontrada");

            return Ok(categoryDto);
        }

        /// <summary>
        /// Retornar uma category pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto == null) return NotFound("Categoria não encontrada");

            return Ok(categoryDto);
        }

        /// <summary>
        /// Adicionar uma nova categoria.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null) return BadRequest("Parâmetro inválido");

            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto);
        }

        /// <summary>
        /// Atualizar uma categoria.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId) return BadRequest();

            if (categoryDto is null) return BadRequest("Parâmetro inválido");

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }

        /// <summary>
        /// Remover uma categoria.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto == null) return BadRequest("Categoria não encontrada");

            await _categoryService.RemoveCategory(id);

            return Ok(categoryDto);
        }
    }
}
