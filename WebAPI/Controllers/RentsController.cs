using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : BaseController<Rent>
    {
        IRentService _rentService;
        public RentsController(IRentService rentService) : base(rentService)
        {
            _rentService = rentService;
        }

        [HttpGet("getallnotreturned")]
        public IActionResult GetAllNotReturned(DateTime lateReturnFromDate)
        {
            var result = _rentService.GetAllNotReturned(lateReturnFromDate);
            return GetIActionResult(result);
        }

        [HttpGet("getrentdetails")]
        public IActionResult GetRentDetails(Expression<Func<Rent, bool>> filter = null)
        {
            var result = _rentService.GetRentDetails(filter);
            return GetIActionResult(result);
        }

        [HttpGet("getallcurentrents")]
        public IActionResult GetAllCurrentRents()
        {
            var result = _rentService.GetAllCurrentRents();
            return GetIActionResult(result);
        }

        [HttpGet("getallavailiblecars")]
        public IActionResult GetAllAvailibleCars()
        {
            var result = _rentService.GetAllAvailibleCars();
            return GetIActionResult(result);
        }
    }
}
