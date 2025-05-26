using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Produto { get; set; }
        public bool Ativo {  get; set; }
        public string Imagem { get; set; }

        public ICollection<EstoqueProdutoModel> EstoqueProdutos { get; set; }
    }
}
