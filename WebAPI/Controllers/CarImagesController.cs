using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageManager _carImageManager;
        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageManager carImageManager, IWebHostEnvironment webHostEnvironment)
        {
            _carImageManager = carImageManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageManager.GetAll();
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("add")]
        public IActionResult Add([FromForm] FileUpload file, [FromForm] int carId)
        {
            if (file.files.Length>0)
            {
                CarImage carImage = new CarImage();
                carImage.Date = DateTime.Now;
                string path = _webHostEnvironment.WebRootPath + "\\images\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Tuple<string, string, string> tuple = GuidHelper.GuidedPath(file.files);
                string guidedPath = tuple.Item2;
                string guidedPathForDb= tuple.Item1;
                using (FileStream fileStream=System.IO.File.Create(Environment.CurrentDirectory + @"\wwwroot\images\" + tuple.Item3))
                {
                    file.files.CopyTo(fileStream);
                    fileStream.Flush();
                }
                carImage.CarId = carId;
                carImage.ImagePath = guidedPathForDb;
                var result = _carImageManager.Add(carImage);
                if (result.IsSuccessful)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Geçerli bir klasör seçiniz!");
            
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageManager.Delete(carImage);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
 
            var result = _carImageManager.Update(carImage);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
