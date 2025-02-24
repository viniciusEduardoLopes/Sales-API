using SaleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Application.DTO
{
    public class SalesDTO
    {
        public int Id { get; set; }
        public List<SalesProductsDTO> Products { get; set; } = new List<SalesProductsDTO>();
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime SaleDate { get; set; }
        public string SaleDateF { get { return SaleDate.ToString("dd/MM/yyyy"); } }
        public Decimal TotalPrice { get; set; }
        public string TotalPriceF { get { return string.Concat("R$ ", TotalPrice); } }
    }
}
