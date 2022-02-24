using Business.Abstract;
using Core.Entities;
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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

         
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAll(); //has three values, Data, Success and Message.
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
        public async Task<IActionResult> GetById(Guid customerId)
        {
            var result = await _customerService.GetById(customerId);
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
        public async Task<IActionResult> Add(CustomerCreationDto customerCreationDto) //this Customer object is actually the client's request
        {

            var result =  await _customerService.Add(customerCreationDto);
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
        public async Task<IActionResult> Delete(Customer customer) //this car object is actually the client's request
        {
            var result = await _customerService.Delete(customer);
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
        public async Task<IActionResult> Update(Customer customer) //this car object is actually the client's request
        {
            var result = await _customerService.Update(customer);
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
