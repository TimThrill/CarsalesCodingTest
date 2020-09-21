using System;
using System.Collections.Generic;
using System.Text;

namespace Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate
{
    public class Car: Vehicle
    {
        public VehicleType VehicleType { get; set; }
        public string Engine { get; set; }
        public int DoorCount { get; set; }
        public int WheelCount { get; set; }
        public BodyType BodyType { get; set; }
    }
}
