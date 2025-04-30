namespace NutriFlowAPI.Models
{
    public class EstoqueAlimento
    {
        public int Id { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataCompra {  get; set; }
        public DateTime DataValidade { get; set; }
        public decimal Preco {  get; set; }
        public string Observacoes { get; set; }

        //Tabela Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        //Tabela Produto
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        // Tabela Categoria
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }  

        //Tabela Marca
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        //Tabela UnidadeMedida
        public int UnidadeMedidaId { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        //Tabela Estabelecimento
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        
    }
}
