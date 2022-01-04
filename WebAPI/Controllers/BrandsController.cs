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

        [HttpGet("getallbrands")]
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

        [HttpGet("getbrandbyid")]
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

        [HttpGet("getbrandsbycountries")]
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
 

        [HttpPost("createbrand")]
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

        [HttpPost("deletebrand")]
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

        [HttpPost("updatebrand")]
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
