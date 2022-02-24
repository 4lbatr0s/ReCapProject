using Business.Abstract;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

         
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _userService.GetAll(); //has three values, Data, Success and Message.
            if (result.Success)
            {
                return Ok(result); //status 200
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("byemail")]
        public async Task<IActionResult> GetById(string email)
        {
            var result = await _userService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("byid")]
        public async Task<IActionResult> GetById(Guid userId)
        {
            var result = await _userService.GetById(userId);
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
        public async Task<IActionResult> Add(User user) //this user object is actually the client's request
        {
            var result = await _userService.Add(user);
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
        public async Task<IActionResult> Delete(User user)
        {
            var result = await _userService.Delete(user);
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
        public async Task<IActionResult> Update(User user) //this car object is actually the client's request
        {
            var result = await _userService.Update(user);
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
