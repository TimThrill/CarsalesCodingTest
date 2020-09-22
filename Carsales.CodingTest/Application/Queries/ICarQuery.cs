using Carsales.CodingTest.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application.Queries
{
    public interface ICarQuery
    {
        Task<ICollection<CarViewModel>> GetCars();
    }
}
