using Microsoft.AspNetCore.Mvc;
using FoodsOnline.API.DTOs.Data;
using FoodsOnline.API.Services.Contracts;

namespace FoodsOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// Retornar todos os produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productDto = await _productService.GetProduct();

            if (productDto == null) return NotFound("Produto não encontrado");

            return Ok(productDto);
        }

        /// <summary>
        /// Retornar um produto pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var productDto = await _productService.GetProductById(id);

            if (productDto == null) return NotFound("Produto não encontrado");

            return Ok(productDto);
        }

        /// <summary>
        /// Adicionar um novo produto.
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto == null) return BadRequest("Parâmetro inválido");

            await _productService.AddProduct(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.ProductId }, productDto);
        }

        /// <summary>
        /// Atualizar um produto.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDTO productDto)
        {
            if (productDto == null) return BadRequest("Parâmetro inválido");

            await _productService.UpdateProduct(productDto);

            return Ok(productDto);
        }

        /// <summary>
        /// Remover um produto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDto = await _productService.GetProductById(id);

            if (productDto == null) return BadRequest("Produto não encontrado");

            await _productService.RemoveProduct(id);

            return Ok(productDto);
        }
    }
}
