using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file, int carId)
        {

            string path = _webHostEnvironment.WebRootPath + "\\Images\\" + carId + "\\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileExtension = System.IO.Path.GetExtension(file.FileName);
            string carImagePath = Guid.NewGuid() + fileExtension;
            string absoultePath = path + carImagePath;

            using (FileStream fileStream = System.IO.File.Create(absoultePath))
            {
                CarImage carImage = new CarImage
                {
                    CarImagePath = carImagePath,
                    CarId = carId,
                    Date = DateTime.Now
                };
                var result = _carImageService.AddByCarId(carImage);
                if (result.Success)
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return Ok(result);
                }
                return BadRequest(result);

            }
        }

        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {

            var result = _carImageService.Add(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getfirstimagebycarid")]
        public IActionResult GetFirstImageByCarId(int carId)
        {
            var result = _carImageService.GetFirstImageByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
