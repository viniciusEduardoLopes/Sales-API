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
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productsRepository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productsRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ProductsDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity
            };

            await _productsRepository.AddAsync(product);
        }

        public async Task UpdateAsync(ProductsDTO productDTO)
        {
            var product = new Product
            {
                Name= productDTO.Name,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity
            };
            await _productsRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productsRepository.DeleteAsync(id);
        }
    }
}
