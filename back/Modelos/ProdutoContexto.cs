using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace back.Modelos
{
    public class ProdutoContexto : DbContext
    {
        public ProdutoContexto(DbContextOptions<ProdutoContexto> options): base(options)
        {
            
        }
        public DbSet<Produto> Produtos{get; set;}
    }
}