using SaleAPI.Domain.Entities;
using SaleAPI.Domain.Interfaces;
using SaleAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Infrastructure.Repositories
{
    public class SalesProductsRepository : ISalesProductsRepository
    {
        private readonly ApplicationDbContext _context;

        public SalesProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<SalesProduct> salesProduct)
        {
            await _context.SalesProducts.AddRangeAsync(salesProduct);
            await _context.SaveChangesAsync();
        }
    }
}
