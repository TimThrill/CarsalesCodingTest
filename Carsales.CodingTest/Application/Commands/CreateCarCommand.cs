using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application.Commands
{
    public class CreateCarCommand
    {
        public Guid Id { get; set; }
        public int VehicleType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int DoorCount { get; set; }
        public int WheelCount { get; set; }
        public int BodyType { get; set; }
    }
}
