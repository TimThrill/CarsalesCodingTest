using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carsales.CodingTest.Application.Commands;
using Carsales.CodingTest.Application.Queries;
using Carsales.CodingTest.Application.ViewModels;
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
        private readonly ICarQuery _carQuery;
        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger,
            ICarQuery carQuery,
            IMediator mediator)
        {
            _logger = logger;
            _carQuery = carQuery;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carQuery.GetCars();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand car)
        {
            await _mediator.Send(car);
            return Ok(true);
        }
    }
}
