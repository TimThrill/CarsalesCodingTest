using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carsales.CodingTest.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Carsales.CodingTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55)
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand car)
        {
            await _mediator.Send(car);
            return Ok(true);
        }
    }
}
