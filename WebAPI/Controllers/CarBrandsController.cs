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
    public class CarBrandsController : ControllerBase
    {
        ICarBrandService _carBrandService;

        public CarBrandsController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }
        [HttpPost("add")]
        public IActionResult Add(CarBrand carBrand)
        {
            var result = _carBrandService.Add(carBrand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(CarBrand carBrand)
        {
            var result = _carBrandService.Delete(carBrand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carBrandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carBrandService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("update")]
        public IActionResult Update(CarBrand carBrand)
        {
            var result = _carBrandService.Update(carBrand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
