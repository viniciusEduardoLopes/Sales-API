using Microsoft.EntityFrameworkCore;
using SaleAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesProduct> SalesProducts {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a chave composta da tabela intermediária
            modelBuilder.Entity<SalesProduct>()
                .HasKey(sp => new { sp.SaleId, sp.ProductId });

            // Configurar relacionamento com Venda
            modelBuilder.Entity<SalesProduct>()
                .HasOne(vp => vp.Sale)
                .WithMany(v => v.SalesProducts)
                .HasForeignKey(vp => vp.SaleId);

            // Configurar relacionamento com Produto
            modelBuilder.Entity<SalesProduct>()
                .HasOne(vp => vp.Product)
                .WithMany(p => p.SalesProducts)
                .HasForeignKey(vp => vp.ProductId);

            modelBuilder.Entity<Sale>()
            .HasOne(v => v.Client) // Uma Venda tem um Cliente
            .WithMany(c => c.Sales) // Um Cliente tem várias Vendas
            .HasForeignKey(v => v.ClientId) // Definição da chave estrangeira
            .OnDelete(DeleteBehavior.Cascade); // Caso o cliente seja deletado, as vendas também serão


            base.OnModelCreating(modelBuilder);
        }
    }
}
