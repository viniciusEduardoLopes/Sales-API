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
        private readonly SalesProductsService _salesProductsService;
        private readonly IClientsRepository _clientsRepository;

        public SalesService(ISalesRepository salesRepository, SalesProductsService salesProductsService, IClientsRepository clientsRepository)
        {
            _salesRepository = salesRepository;
            _salesProductsService = salesProductsService;
            _clientsRepository = clientsRepository;
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
            var client = await _clientsRepository.GetByIdAsync(saleDTO.ClientId);
            if (client == null)
                throw new Exception("Cliente não encontrado!");

            var sale = new Sale
            {
                ClientId = saleDTO.ClientId,
                Client = client,
                SaleDate = DateTime.Now,
                Amount=saleDTO.Amount,
                TotalPrice = saleDTO.TotalPrice
            };

            await _salesRepository.AddAsync(sale);

            await _salesProductsService.AddAsync(sale.Id, saleDTO.Products);
        }

        public async Task UpdateAsync(SalesDTO saleDTO)
        {
            var sale = new Sale
            {
                SaleUpdate = DateTime.Now
                
            };
            await _salesRepository.UpdateAsync(sale);
        }

        public async Task DeleteAsync(int id)
        {
            await _salesRepository.DeleteAsync(id);
        }
    }
}
