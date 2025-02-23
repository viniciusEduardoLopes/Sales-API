using SaleAPI.Application.DTO;
using SaleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Application.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(ProductsDTO productDTO);
        Task UpdateAsync(ProductsDTO productDTO);
        Task DeleteAsync(int id);
    }
}
