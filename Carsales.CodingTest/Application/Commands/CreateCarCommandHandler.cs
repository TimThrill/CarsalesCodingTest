using AutoMapper;
using Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application.Commands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }
            
        public async Task<Unit> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var newCar = _mapper.Map<Car>(request);

            await _carRepository.AddCar(newCar);

            await _carRepository.UnitOfWork.SaveEntitiesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
