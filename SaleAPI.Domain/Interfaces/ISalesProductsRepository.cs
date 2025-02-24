using SaleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Domain.Interfaces
{
    public interface ISalesProductsRepository
    {
        Task AddRangeAsync(List<SalesProduct> salesProduct);
    }
}
