namespace NutriFlowAPI.Models
{
    public class UnidadeMedida
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<EstoqueAlimento> Estoque { get; set; }

    }
}
