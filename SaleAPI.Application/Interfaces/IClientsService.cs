using SaleAPI.Application.DTO;
using SaleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Application.Interfaces
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task AddAsync(ClientsDTO saleDTO);
        Task UpdateAsync(ClientsDTO saleDTO);
        Task DeleteAsync(int id);
    }
}
