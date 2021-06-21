using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
      
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<Product> _productsRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IGenericRepository<ProductBrand> productBrandRepo
           )
        {
           
            _productsRepo = productsRepo;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> getProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(spec);
            return products.Select(product=>new ProductToReturnDto
            {
                Id=product.Id,
                Name=product.Name,
                Description=product.Description,
                PictureUrl=product.PictureUrl,
                Price=product.Price,
                ProductBrand=product.ProductBrand.Name,
                ProductType=product.ProductType.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> getProducts(int id)
        {
           var spec = new ProductsWithTypesAndBrandsSpecification(id);
           var product= await _productsRepo.GetEntityWithSpec(spec);
           return new ProductToReturnDto
            {
                Id=product.Id,
                Name=product.Name,
                Description=product.Description,
                PictureUrl=product.PictureUrl,
                Price=product.Price,
                ProductBrand=product.ProductBrand.Name,
                ProductType=product.ProductType.Name
           };

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