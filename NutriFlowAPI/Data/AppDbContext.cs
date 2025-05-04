using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Models;
using NutriFlowAPI.Models.Usuario;

namespace NutriFlowAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PaisModel> Paises { get; set; }
        public DbSet<CidadeModel> Cidades { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<MarcaModel> Marcas { get; set; }
        public DbSet<UnidadeMedidaModel> UnidadeMedidas { get; set; }
        public DbSet<EstabelecimentoModel> Estabelecimentos { get; set; }
        public DbSet<EstoqueProdutoModel> EstoqueProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstoqueProdutoModel>()
                .Property(e => e.Preco)
                .HasPrecision(18, 2);

            modelBuilder.Entity<EstoqueProdutoModel>()
                .Property(e => e.Quantidade)
                .HasPrecision(18, 2);
        }
    };


}
