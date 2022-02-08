using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll(); //has three values, Data, Success and Message.
            if (result.Success)
            {
                return Ok(result); //status 200
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("byid")]
        public IActionResult GetById(int carId)
        {
            var result = _brandService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("bycountry")]
        public IActionResult GetCarsByBrandId(string countryName)
        {
            var result = _brandService.GetByCountry(countryName);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
 

        [HttpPost("create")]
        public IActionResult Add(Brand brand) //this car object is actually the client's request
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand) //this car object is actually the client's request
        {
            var result = _brandService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand) //this car object is actually the client's request
        {
            var result = _brandService.Update(brand);
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
