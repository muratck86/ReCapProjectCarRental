using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
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
    public class BaseController<T> : ControllerBase where T: class, IEntity, new()
    {
        IVehicleRentalBaseService<T> _vehicleRentalBaseService;

        public BaseController(IVehicleRentalBaseService<T> vehicleRentalBaseService)
        {
            _vehicleRentalBaseService = vehicleRentalBaseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _vehicleRentalBaseService.GetAll();
            return GetIActionResult(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleRentalBaseService.GetById(id);
            return GetIActionResult(result);
        }

        [HttpPost("add")]
        public IActionResult Add(T entity)
        {
            var result = _vehicleRentalBaseService.Add(entity);
            return GetIActionResult(result);
        }

        [HttpPost("update")]
        public IActionResult Update(T entity)
        {
            var result = _vehicleRentalBaseService.Update(entity);
            return GetIActionResult(result);
        }

        [HttpPost("removebyid")]
        public IActionResult RemoveById(int id)
        {
            var toDelete = _vehicleRentalBaseService.GetById(id);
            if (toDelete.Success)
            {
                return Remove(toDelete.Data);
            }
            return GetIActionResult(toDelete);
        }
        [HttpPost("remove")]
        public IActionResult Remove(T entity)
        {
            var result = _vehicleRentalBaseService.Remove(entity);
            return GetIActionResult(result);
        }



        //Helper Method(and 2 overloads) 1-For List of Entites
        internal IActionResult GetIActionResult(IDataResult<List<T>> result)
        {
            if (result.Success && result.Data != null)
                return Ok(result); //200
            else if (result.Success && result.Data == null)
                return Content(result.Message);
            return BadRequest(result); //400
        }

        //Overload-2: if data is an Entity
        internal IActionResult GetIActionResult(IDataResult<T> result)
        {
            if (result.Success && result.Data != null)
                return Ok(result); //200
            else if (result.Success && result.Data == null)
                return Content(result.Message);
            return BadRequest(result); //400
        }

        //Overload-3: if there is no data.
        internal IActionResult GetIActionResult(IResult result)
        {
            if (result.Success)
                return Ok(result);  //200
            return BadRequest(result); //400
        }
    }
}
