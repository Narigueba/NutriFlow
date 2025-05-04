using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        public string Categoria { get; set; }
        public ICollection<EstoqueProdutoModel> EstoqueProdutos { get; set; }
    }
}
