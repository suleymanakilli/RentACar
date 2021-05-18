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
    public class CreditCardsController : ControllerBase
    {
        ICreditCardManager _creditCardManager;
        public CreditCardsController(ICreditCardManager creditCardManager)
        {
            _creditCardManager = creditCardManager;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _creditCardManager.GetAll();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _creditCardManager.GetByCustomerId(customerId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardManager.Add(creditCard);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("pay")]
        public IActionResult Pay(CreditCard creditCard)
        {
            var result = _creditCardManager.Pay(creditCard);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("checkifvalid")]
        public IActionResult CheckIfValid(CreditCard creditCard)
        {
            var result = _creditCardManager.CheckIfValid(creditCard);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _creditCardManager.Delete(creditCard);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCard creditCard)
        {
            var result = _creditCardManager.Update(creditCard);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
