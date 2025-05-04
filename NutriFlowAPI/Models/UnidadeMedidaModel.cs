namespace NutriFlowAPI.Models
{
    public class UnidadeMedidaModel
    {
        public int Id { get; set; }
        public string UnidadeMedida {  get; set; }
        public string Sigla { get; set; } // ml, l, cx, pct, etc
        public ICollection<EstoqueProdutoModel> EstoqueProdutos { get; set; }
    }
}
