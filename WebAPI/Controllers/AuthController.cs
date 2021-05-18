using Business.Abstract;
using Entities.Dtos;
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
    public class AuthController : ControllerBase
    {
        IAuthManager _authManager;
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authManager.Login(userForLoginDto);
            if (!userToLogin.IsSuccessful)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authManager.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authManager.UserExist(userForRegisterDto.Email);
            if (!userExists.IsSuccessful)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authManager.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authManager.CreateAccessToken(registerResult.Data);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }
}
