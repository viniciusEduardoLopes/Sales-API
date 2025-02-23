using SaleAPI.Application.DTO;
using SaleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Application.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesDTO>> GetAllAsync();
        Task<SalesDTO?> GetByIdAsync(int id);
        Task AddAsync(SalesDTO saleDTO);
        Task UpdateAsync(SalesDTO saleDTO);
        Task DeleteAsync(int id);
    }
}
