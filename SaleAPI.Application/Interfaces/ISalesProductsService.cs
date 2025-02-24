using SaleAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Application.Interfaces
{
    public interface ISalesProductsService
    {
        Task AddAsync(SalesProductsDTO salesProductsDTO);
    }
}
