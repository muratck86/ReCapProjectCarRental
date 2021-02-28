using Business.Abstract;
using Core.DataAccess.FileIO;
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
    public class CarImagesController : ControllerBase //BaseController<CarImage>
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService) //: base(carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("addimage")]
        public IActionResult AddImage([FromForm] IFormFile image, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddImage(image, carImage);
            if (result.Success)
            {
                return StatusCode(201, result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateimage")]
        public IActionResult UpdateImage(FormFile image, CarImage carImage)
        {
            var result = _carImageService.UpdateImage(image, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
