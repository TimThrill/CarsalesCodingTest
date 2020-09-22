using Carsales.CodingTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carsales.CodingTest.Test.Helpers
{
    public static class Utilities
    {
        private static readonly object _lock = new object();
        private static bool _hasInstance = false;

        public static void InitializeDbForTests(CarsalesDbContext db)
        {
            // Use a lock to avoid this method calling twice
            // Ref: https://github.com/dotnet/aspnetcore/issues/20307
            lock (_lock)
            {
                if (!_hasInstance)
                {
                    _hasInstance = true;
                }
            }
        }
    }
}
