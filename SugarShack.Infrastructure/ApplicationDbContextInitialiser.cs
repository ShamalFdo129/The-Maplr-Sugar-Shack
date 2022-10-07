using Microsoft.Extensions.Logging;

using SugarShack.Domain.Entities;

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
            _context.Products.AddRange(new List<Product>() { new Product { Name = "X", Price =24.50 },
                    new Product { Name = "Y", Price =24.50  },
                    new Product { Name = "Z", Price =24.50  },
                    new Product { Name = "J", Price =24.50  }});

            await _context.SaveChangesAsync();
        }
    }

}
