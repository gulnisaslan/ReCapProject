using Business.Abstract;
using Core.Utilities.Results;
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
    public class CarColoursController : ControllerBase
    {
        ICarColourService _carColourService;

        public CarColoursController(ICarColourService carColourService)
        {
            _carColourService = carColourService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carColourService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(CarColour carColour)
        {
            var result = _carColourService.Add(carColour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
      
        [HttpDelete("delete")]
        public IActionResult Delete(CarColour carColour)
        {
            var result = _carColourService.Delete(carColour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("update")]
        public IActionResult Update(CarColour carColour)
        {
            var result = _carColourService.Update(carColour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carColourService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    


    }
}
