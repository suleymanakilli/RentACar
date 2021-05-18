using Business.Abstract;
using Core.Entities.Concrete;
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
    public class UsersController : ControllerBase
    {
        IUserManager _userManager;
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userManager.GetAll();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userManager.Add(user);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userManager.Delete(user);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userManager.Update(user);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbymail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userManager.GetUserDtoByMail(email);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getclaims")]
        public IActionResult GetClaims(User user)
        {
            var result = _userManager.GetClaims(user);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
