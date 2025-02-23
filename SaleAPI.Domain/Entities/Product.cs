﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Relacionamento muitos-para-muitos com Venda
        public ICollection<SalesProduct> SalesProducts { get; set; } = new List<SalesProduct>();
    }
}
