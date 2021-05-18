using Business.Abstract;
using DataAccess.Abstract;
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
    public class CarsController : ControllerBase
    {
        ICarManager _carManager;
        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;

            
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carManager.GetAll();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbycarid")]
        public IActionResult GetCarDetailsByCarId(int carId)
        {
            var result = _carManager.GetCarDetailsByCarId(carId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbyfilter")]
        public IActionResult GetCarDetailsByFilter(int brandId,int colorId)
        {
            var result = _carManager.GetCarDetailsByFilter(brandId, colorId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carManager.GetAllCarDetails();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _carManager.GetById(id);
            if (result.IsSuccessful) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
/*
        [HttpGet("getcardetails")]

        public IActionResult GetCarDetails()
        {
            var result = _carManager.GetCarDetails();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }*/

        [HttpGet("getcarsbyfilter")]
        public IActionResult GetCarsByFilter(int brandId,int colorId)
        {
            var result = _carManager.GetByBrandAndColorId(brandId,colorId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.Delete(car);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carManager.Update(car);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionTest(Car car)
        {
            var result = _carManager.TransactionTest(car);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
