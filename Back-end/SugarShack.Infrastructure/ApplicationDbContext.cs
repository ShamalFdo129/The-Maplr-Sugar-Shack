using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using SugarShack.Application.Common.Interfaces;
using SugarShack.Domain.Entities;
using SugarShack.Infrastructure.Interceptors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }
        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<Cart> Carts => Set<Cart>();
        public virtual DbSet<CartLineItem> CartLineItems => Set<CartLineItem>();
        public virtual DbSet<Order> Orders => Set<Order>();
        public virtual DbSet<OrderLineItem> OrderLineItems => Set<OrderLineItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
