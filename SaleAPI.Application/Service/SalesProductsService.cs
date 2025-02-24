using SaleAPI.Application.DTO;
using SaleAPI.Application.Interfaces;
using SaleAPI.Domain.Entities;
using SaleAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Application.Service
{
    public class SalesProductsService
    {
        private readonly ISalesProductsRepository _salesProductsRepository;

        public SalesProductsService(ISalesProductsRepository salesProductsRepository)
        {
            _salesProductsRepository = salesProductsRepository;
        }
        public async Task AddAsync(int saleId, List<SalesProductsDTO> salesProducts)
        {
            var domain = salesProducts.Select(sp => new SalesProduct 
            { 
                Date = DateTime.Now,
                SaleId = saleId,
                ProductId = sp.ProductId,
                Quantity = sp.Quantity
            }).ToList();

            await _salesProductsRepository.AddRangeAsync(domain);
        }
    }
}
