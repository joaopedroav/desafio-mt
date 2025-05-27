using backend_mt.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_mt.Utils
{
    public class BackendContext : DbContext
    {
        public BackendContext(DbContextOptions<BackendContext> options)
        : base(options)
        {
        }


        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<ProdutoGrid> ProdutosGrid { get; set; } = null!;
        public DbSet<Departamento> Departamentos { get; set; } = null!;

    }
}
