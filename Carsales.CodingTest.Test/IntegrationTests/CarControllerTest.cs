using Carsales.CodingTest.Application.Commands;
using Carsales.CodingTest.Application.ViewModels;
using Carsales.CodingTest.Domain;
using Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Carsales.CodingTest.Test.IntegrationTests
{
    public class CarControllerTest: IClassFixture<CarsalesWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CarsalesWebApplicationFactory<Startup> _factory;

        public CarControllerTest(CarsalesWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Post_CreateCar_Success()
        {
            var content = new StringContent(JsonSerializer.Serialize<CreateCarCommand>(
                new CreateCarCommand
                {
                    Id = Guid.NewGuid(),
                    Make = "Honda",
                    Model = "CRV",
                    Engine = "Z24",
                    DoorCount = 4,
                    WheelCount = 4,
                    BodyType = (int)BodyType.Hatchback,
                    VehicleType = (int)VehicleType.Car
                }), Encoding.UTF8, "application/json");
            var expectedCarNumber = 1;

            // Act
            await _client.PostAsync("api/Car", content);
            var allCars = await (await _client.GetAsync("api/Car")).Content.ReadAsStringAsync();
            var cars = JsonSerializer.Deserialize<ICollection<CarViewModel>>(allCars);

            // Assert
            Assert.Equal(expectedCarNumber, cars.Count);
        }

        [Fact]
        public async Task Post_CreateCarWithNegtiveDoorNumber_Failed()
        {
            var content = new StringContent(JsonSerializer.Serialize<CreateCarCommand>(
                new CreateCarCommand
                {
                    Id = Guid.NewGuid(),
                    Make = "Honda",
                    Model = "CRV",
                    Engine = "Z24",
                    DoorCount = -1,
                    WheelCount = 4,
                    BodyType = (int)BodyType.Hatchback,
                    VehicleType = (int)VehicleType.Car
                }), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/Car", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
