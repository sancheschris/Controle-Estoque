using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Models.Data
{
    public class StockContext : DbContext
    {

        public StockContext(DbContextOptions<StockContext> options) :base(options)
        {}

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

    }
}
