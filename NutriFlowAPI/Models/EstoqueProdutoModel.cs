using NutriFlowAPI.Models.Usuario;
using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models
{
    public class EstoqueProdutoModel
    {
        [Key]

        public int Id { get; set; }
        public UsuarioModel Usuario { get; set; }
        public CategoriaModel Categoria { get; set; }
        public ProdutoModel Produto { get; set; }
        public MarcaModel Marca { get; set; }
        public decimal Quantidade { get; set; }
        public UnidadeMedidaModel UnidadeMedida { get; set; }
        public decimal Preco {  get; set; }
        public EstabelecimentoModel Estabelecimento { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public DateTime? DataValidade {  get; set; }
        public string? Descricao { get; set; }
        public bool Ativo {  get; set; }
    }
}
