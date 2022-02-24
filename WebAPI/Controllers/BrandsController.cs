using Business.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async  Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAll(); //has three values, Data, Success and Message.
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
        public async Task<IActionResult> GetById(Guid carId)
        {
            var result = await _brandService.GetById(carId);
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
        public async Task<IActionResult> GetCarsByBrandId(string countryName)
        {
            var result =  await _brandService.GetByCountry(countryName);
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
        public async Task<IActionResult> Add(BrandForCreationDto brand) //this car object is actually the client's request
        {
            var result = await _brandService.Add(brand);
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
        public async Task<IActionResult> Delete(Brand brand)
        {
            var result = await _brandService.Delete(brand);
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
        public async Task<IActionResult> Update(Brand brand)
        {
            var result = await _brandService.Update(brand);
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
