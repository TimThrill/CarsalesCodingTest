using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate
{
    public interface ICarRepository: IRepository<Car>
    {
        Task<Car> AddCar(Car car);
        Task<ICollection<Car>> GetCars();
    }
}
