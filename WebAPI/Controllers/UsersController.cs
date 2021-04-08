using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbymail")]
        public ActionResult GetUserDetail(string mail)
        {
            var result = _userService.GetByMail(mail);
            UserDetailDto userDetail = new UserDetailDto
            {
                FirstName = result.FirstName,
            LastName = result.LastName,
            UserId = result.Id,
            
            };
            var result1 = new SuccessDataResult<UserDetailDto>(userDetail);
            return Ok(result1);

        }
        [HttpPost("getclaims")]
        public IActionResult GetClaims(User user)
        {
            var result = _userService.GetClaims(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }   
    }
}
