using Microsoft.Extensions.Logging;

using SugarShack.Domain.Entities;
using SugarShack.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShack.Infrastructure
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            _context.Products.AddRange(new List<Product>() { new Product { Name = "Maple syrup Special", Price =8.50, Type = Catalogue.Amber},
                    new Product {  Name = "Maple syrup added honey", Price =10.50, Type = Catalogue.Dark },
                    new Product {  Name = "Maple syrup Original", Price =6.50, Type = Catalogue.Clear  },
                    new Product {  Name = "Maple syrup Regular", Price =7.50, Type = Catalogue.Amber  }});

            await _context.SaveChangesAsync();
        }
    }

}
