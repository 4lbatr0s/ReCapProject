using Business.Abstract;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

         
        [HttpGet("getallusers")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll(); //has three values, Data, Success and Message.
            if (result.Success)
            {
                return Ok(result); //status 200
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getrentalbyid")]
        public IActionResult GetById(int rentalId)
        {
            var result = _rentalService.GetById(rentalId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


        [HttpPost("createrental")]
        public IActionResult Add(Rental rental) //this rental object is actually the client's request
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("deleterental")]
        public IActionResult Delete(Rental rental) //this car object is actually the client's request
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("updaterental")]
        public IActionResult Update(Rental rental) //this car object is actually the client's request
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

      
    }
}
