using Business.Abstract;
using Core.Entities.Concrete;
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
        public User GetBymail(string mail)
        {
            var result = _userService.GetByMail(mail);
            return result;
            
        }
        [HttpGet("getclaims")]
        public List<OperationClaim> GetClaims(User user)
        {
            var result = _userService.GetClaims(user);
            return result;

        }
    }
}
