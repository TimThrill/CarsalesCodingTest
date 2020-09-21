using AutoMapper;
using Carsales.CodingTest.Application.Commands;
using Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>();
        }
    }
}
