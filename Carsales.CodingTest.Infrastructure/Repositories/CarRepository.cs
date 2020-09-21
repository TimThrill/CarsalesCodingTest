using Carsales.CodingTest.Domain;
using Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarsalesDbContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public CarRepository(CarsalesDbContext context)
        {
            _context = context;
        }

        public async Task<Car> AddCar(Car car)
        {
            await _context.Cars.AddAsync(car);

            return car;
        }
    }
}
