using System;
using System.Collections.Generic;
using System.Text;

namespace Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
