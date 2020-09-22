using AutoMapper;
using Carsales.CodingTest.Application.ViewModels;
using Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application.Queries
{
    public class CarQuery : ICarQuery
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarQuery(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CarViewModel>> GetCars()
        {
            var cars = _mapper.Map<ICollection<CarViewModel>>(await _carRepository.GetCars());
            return cars;
        }
    }
}
