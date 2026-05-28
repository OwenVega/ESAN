using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPING.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var product = await _productService.GetProductByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);


        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO productCreateDTO)
        {
            await _productService.CreateProduct(productCreateDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            await _productService.UpdateProduct(productUpdateDTO);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();


        }
    }
}
