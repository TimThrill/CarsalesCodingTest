using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application.Exceptions
{
    public class CarException: Exception
    {
        public CarException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
