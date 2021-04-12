using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {
        [HttpGet]
        public string getProducts(){
            return " List of prodct";

        }

        [HttpGet("{id}")]
        public string getProducts(int id){
            return " single  of prodct";

        }
        
    }
}