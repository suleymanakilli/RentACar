using Business.Abstract;
using Entities.Concrete;
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
    public class BrandsController : ControllerBase
    {
        IBrandManager _brandManager;
        public BrandsController(IBrandManager brandService)
        {
            _brandManager = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandManager.GetAll();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandManager.Add(brand);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandManager.Delete(brand);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandManager.Update(brand);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
