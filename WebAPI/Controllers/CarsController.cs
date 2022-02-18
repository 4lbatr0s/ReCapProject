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
        public IActionResult GetAll()
        {
            var result =  _carService.GetAll(); //has three values, Data, Success and Message.
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
        public IActionResult GetById(Guid carId)
        {
            var result = _carService.GetById(carId);
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
        public IActionResult GetCarsByBrandId(Guid brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
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
        public IActionResult GetCarsByColorId(Guid brandId)
        {
            var result = _carService.GetCarsByColorId(brandId); 
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
        public IActionResult Add(CarForCreationDto carForCreationDto) //this car object is actually the client's request
        {
            var result = _carService.Add(carForCreationDto);
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
        public IActionResult Delete(Car car) //this car object is actually the client's request
        {
            var result = _carService.Delete(car);
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
        public IActionResult Update(Car car) //this car object is actually the client's request
        {
            var result = _carService.Update(car);
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
    }
}
