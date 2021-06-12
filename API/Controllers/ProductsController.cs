using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
      
        private read only IGenericRepository <Product>  _productsRepo;
        private read only IGenericRepository <ProductBrand>  _productBrandRepo;
        private read only IGenericRepository <ProductType>  _productTypeRepo;

        public ProductsController(
            IGenericRepository <Product> productsRepo
           ,IGenericRepository <ProductBrand> productBrandRepo
           ,IGenericRepository <ProductType> productTypeRepo
           
           )
        {
            
            _productsRepo=productsRepo;
            _productBrandRepo=productBrandRepo;
            _productTypeRepo=productTypeRepo;

        


        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var products = await _productsRepo.ListAllAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProducts(int id)
        {
            return await _productsRepo.GetByIdAsync(id);

        }

         [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

       
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

    }
}