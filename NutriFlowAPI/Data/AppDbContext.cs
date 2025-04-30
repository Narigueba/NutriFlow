using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Models;

namespace NutriFlowAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Db Sets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<EstoqueAlimento> EstoqueAlimentos { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relacionamento de tabelas

            modelBuilder.Entity<EstoqueAlimento>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId);

            modelBuilder.Entity<EstoqueAlimento>()
                .HasOne(e => e.Produto)
                .WithMany(p => p.Estoque)
                .HasForeignKey(e => e.ProdutoId);

            modelBuilder.Entity<EstoqueAlimento>()
                .HasOne(e => e.Marca)
                .WithMany(m => m.Estoque)
                .HasForeignKey(e => e.MarcaId);

            modelBuilder.Entity<EstoqueAlimento>()
                .HasOne(e => e.Estabelecimento)
                .WithMany()
                .HasForeignKey(e => e.EstabelecimentoId);

            modelBuilder.Entity<EstoqueAlimento>()
                .HasOne(e => e.UnidadeMedida)
                .WithMany()
                .HasForeignKey(e => e.UnidadeMedidaId);

            modelBuilder.Entity<EstoqueAlimento>()
                .HasOne(e => e.Categoria)
                .WithMany()
                .HasForeignKey(e => e.CategoriaId);

        }


    }
}
