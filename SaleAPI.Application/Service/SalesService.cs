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
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;

        public SalesService(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public async Task<IEnumerable<SalesDTO>> GetAllAsync()
        {
            var sales = await _salesRepository.GetAllAsync();
            if (sales == null)
                return new List<SalesDTO>();

            return sales.Select(s => new SalesDTO 
            {
                Id = s.Id,
                SaleDate = s.SaleDate,
                ClientName = s.Client.Name,
                TotalPrice = s.TotalPrice
            });

        }

        public async Task<SalesDTO?> GetByIdAsync(int id)
        {
            var sale = await _salesRepository.GetByIdAsync(id);
            if (sale == null) return null;
            return new SalesDTO 
            {
                Id=sale.Id,
                SaleDate=sale.SaleDate,
                ClientName = sale.Client.Name,
                Amount = sale.Amount,
                TotalPrice = sale.TotalPrice
            };
        }

        public async Task AddAsync(SalesDTO saleDTO)
        {
            var sale = new Sale
            {
                ClientId = saleDTO.ClientId,
                SaleDate = DateTime.Now,
                //Products = saleDTO.Products,
                //SalesProducts = saleDTO.SalesProducts,
                //TotalPrice = saleDTO.SalesProducts.Select(p => p.Product).ToList().Select(s => s.Price).Sum(),
            };

            await _salesRepository.AddAsync(sale);
        }

        public async Task UpdateAsync(SalesDTO saleDTO)
        {
            var sale = new Sale
            {
                SaleUpdate = DateTime.Now,
                TotalPrice = saleDTO.Products.Select(p => p.Price).Sum(),
            };
            await _salesRepository.UpdateAsync(sale);
        }

        public async Task DeleteAsync(int id)
        {
            await _salesRepository.DeleteAsync(id);
        }
    }
}
