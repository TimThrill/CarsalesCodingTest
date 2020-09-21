using Carsales.CodingTest.Domain;
using Carsales.CodingTest.Domain.AggregatesModel.VehicleAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Infrastructure
{
    public class CarsalesDbContext: DbContext, IUnitOfWork
    {
        public DbSet<Car> Cars { get; set; }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync();
        }
    }
}
