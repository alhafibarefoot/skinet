using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {

        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42); //assuming a product with id=42

            if (thing == null) return NotFound(new ApiResponse(404));

            return Ok();
        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString(); //In case null , we will get error becuase I cant conver null to string

            return Ok();
        }


        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400)); //this will return 400 bad request
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id) //simply we got error if we pass string not INT
        {
            return Ok();
        }
        
    }
}