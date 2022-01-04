using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ColorsController:ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getallcolors")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getcolorbyid")]
        public IActionResult GetById(int colorId)
        {
            var result = _colorService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("createcolor")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("deletecolor")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("updatecolor")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if(result.Success)
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