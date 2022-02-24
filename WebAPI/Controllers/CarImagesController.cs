using Business.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        //private readonly 

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

       
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] CarImageForCreationDto carImage)
        {
            var result =  await _carImageService.UploadImage(file, carImage);
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var result = await _carImageService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("byid")]
        public async Task<IActionResult> GetById(Guid carImageId)
        {
            var result = await _carImageService.GetById(carImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = await _carImageService.Update(file, carImage);
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(CarImage  carImage)
        {
            var result = await _carImageService.Delete(carImage);
            if(result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
