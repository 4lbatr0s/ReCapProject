using Business.Abstract;
using Entities;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

         
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _rentalService.GetAll(); //has three values, Data, Success and Message.
            if (result.Success)
            {
                return Ok(result); //status 200
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("alldetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            var result = await _rentalService.GetRentalDetails(); //has three values, Data, Success and Message.
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
        public async Task<IActionResult> GetById(Guid rentalId)
        {
            var result = await _rentalService.GetById(rentalId);
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
        public async Task<IActionResult> Add(RentalForCreationDto rentalForCreationDto)
        {
            var result = await _rentalService.Add(rentalForCreationDto);
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
        public async Task<IActionResult> Delete(Rental rental) //this car object is actually the client's request
        {
            var result = await _rentalService.Delete(rental);
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
        public async Task<IActionResult> Update(Rental rental)
        {
            var result = await _rentalService.Update(rental);
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
