using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models
{
    public class EstabelecimentoModel
    {
        [Key]
        public int Id {  get; set; }
        public string Estabelecimento { get; set; }
        public string Endereco { get; set; }
        public bool Ativo { get; set; }
        public ICollection<EstoqueProdutoModel> EstoqueProdutos { get; set; }
    }
}
