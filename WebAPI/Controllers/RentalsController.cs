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
    public class RentalsController : ControllerBase
    {
        IRentalManager _rentalManager;
        public RentalsController(IRentalManager rentalManager)
        {
            _rentalManager = rentalManager;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalManager.GetAll();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            var result = _rentalManager.GetById(carId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getlastrentalbyid")]
        public IActionResult GetLastRentalById(int carId)
        {
            var result = _rentalManager.GetLastRentalById(carId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("checkifavailable")]
        public IActionResult CheckIfAvailable(Rental rental)
        {
            rental.CustomerId = 1;
            var result = _rentalManager.CheckIfAvailable(rental);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalManager.Add(rental);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalManager.Delete(rental);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalManager.Update(rental);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
