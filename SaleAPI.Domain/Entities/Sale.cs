using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Domain.Entities
{
    public class Sale
    {
        public Sale()
        {
            
        }
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime SaleUpdate { get; set; }
        public decimal TotalPrice { get; set; }

        // Relacionamento: Uma venda pertence a um cliente
        public int ClientId { get; set; }
        public Client Client { get; set; } = new Client();

        // Relacionamento muitos-para-muitos com Produto
        public ICollection<SalesProduct> SalesProducts { get; set; } = new List<SalesProduct>();
    }

    public class SalesProduct
    {
        public int SaleId { get; set; }
        public Sale Sale { get; set; } = new Sale();

        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();

        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
