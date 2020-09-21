using System;
using System.Collections.Generic;
using System.Text;

namespace Carsales.CodingTest.Domain
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
