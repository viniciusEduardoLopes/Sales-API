using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relacionamento: Um cliente pode ter várias vendas
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
