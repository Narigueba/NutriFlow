namespace NutriFlowAPI.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<EstoqueAlimento> Estoque { get; set; }
    }
}
