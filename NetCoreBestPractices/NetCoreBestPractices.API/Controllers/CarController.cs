using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<CarDto>>> GetAll()
        {
            var cars = await _carService.GetAllAsync();
            var carDtos = _mapper.Map<IEnumerable<CarDto>>(cars);
            return Ok(carDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetById(long id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var carDto = _mapper.Map<CarDto>(car);
            return Ok(carDto);
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> Create(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            var newCar = await _carService.AddAsync(car);
            var newCarDto = _mapper.Map<CarDto>(newCar);
            return CreatedAtAction(nameof(GetById), new { id = newCarDto.Id }, newCarDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, CarDto carDto)
        {
            if (id != carDto.Id)
            {
                return BadRequest();
            }
            var car = _mapper.Map<Car>(carDto);
            await _carService.UpdateAsync(car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            await _carService.RemoveAsync(car);
            return NoContent();
        }
    }
}
