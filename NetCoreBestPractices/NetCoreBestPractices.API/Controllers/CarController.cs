using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreBestPractices.API.DTO.Car;
using NetCoreBestPractices.Core.Entities;
using NetCoreBestPractices.Core.Services;

namespace NetCoreBestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _carService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CarDto>>(cars));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var car = await _carService.GetByIdAsync(id);
            return Ok(_mapper.Map<CarDto>(car));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarDto car)
        {
            var insertedCar = await _carService.AddAsync(_mapper.Map<Car>(car));
            return Created(String.Empty, _mapper.Map<CarDto>(insertedCar));
        }

        [HttpPut]
        public IActionResult Update(CarDto car)
        {
            var updatedCar = _carService.Update(_mapper.Map<Car>(car));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            var removedCar = _carService.GetByIdAsync(id).Result;
            _carService.Remove(removedCar);
            return NoContent();
        }
    }
}
