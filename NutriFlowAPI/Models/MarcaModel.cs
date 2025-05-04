using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models
{
    public class MarcaModel
    {
        [Key]
        public int Id { get; set; }
        public string Marca { get; set; }
        public ICollection<EstoqueProdutoModel> EstoqueProdutos { get; set; }
    }
}
