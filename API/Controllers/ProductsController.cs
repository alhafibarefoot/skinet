using System.Collections.Generic;
using System.Threading.Tasks;using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        public IGenericRepository Repo { get; }

        public ProductsController(
            IGenericRepository <Product> productRepo
           ,IGenericRepository <ProductBrand> productBrandRepo
           
           )
        {
            
        


        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProducts(int id)
        {
            return await _repo.GetProductByIDAsync(id);

        }

         [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

       
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }

    }
}