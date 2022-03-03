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
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result =  await _carService.GetAll(); //has three values, Data, Success and Message.
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
            var result = await _carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("bybrandid")]
        public async Task<IActionResult> GetCarsByBrandId(Guid brandId)
        {
            var result = await _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("bycolorid")]
        public async Task<IActionResult> GetCarsByColorId(Guid brandId)
        {
            var result = await _carService.GetCarsByColorId(brandId); 
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
        public async Task<IActionResult> Add(CarForCreationDto carForCreationDto) //this car object is actually the client's request
        {
            var result = await _carService.Add(carForCreationDto);
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
        public async Task<IActionResult> Delete(Car car)
        {
            var result = await _carService.Delete(car);
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
        public async Task<IActionResult> Update(Car car)
        {
            var result = await _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetCarDetails()
        {
            var result = await _carService.GetCarDetails();
            
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("detailsbycolorid")]
        public async Task<IActionResult> GetCarDetailsByColorId(Guid colorId)
        {
            var result = await _carService.GetCarDetailsByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("detailsbybrandid")]
        public async Task<IActionResult> GetCarDetailsByBrandId(Guid brandId)
        {
            var result = await _carService.GetCarDetailsByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("detailsbyid")]
        public async Task<IActionResult> GetCarDetailsById(Guid carId)
        {
            var result = await _carService.GetCarDetailsById(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
