using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.UnitTest
{
    internal static class MockingHelper
    {
        public static Mock<DbSet<EntityType>> GetMockedDbSet<EntityType>(List<EntityType> items) where EntityType : class
        {
            var data = items.AsQueryable();

            var mockDbSetEntities = new Mock<DbSet<EntityType>>();
            mockDbSetEntities.As<IQueryable<EntityType>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSetEntities.As<IQueryable<EntityType>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSetEntities.As<IQueryable<EntityType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSetEntities.As<IQueryable<EntityType>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockDbSetEntities;
        }
    }
}
