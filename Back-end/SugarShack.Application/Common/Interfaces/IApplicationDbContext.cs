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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
