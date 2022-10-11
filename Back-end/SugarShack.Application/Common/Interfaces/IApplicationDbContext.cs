using Microsoft.EntityFrameworkCore;

using SugarShack.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<SugarShack.Domain.Entities.Product> Products { get; }
        DbSet<SugarShack.Domain.Entities.Cart> Carts { get; }
        DbSet<SugarShack.Domain.Entities.CartLineItem> CartLineItems { get; }
        DbSet<SugarShack.Domain.Entities.Order> Orders { get; }
        DbSet<SugarShack.Domain.Entities.OrderLineItem> OrderLineItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();

    }
}
