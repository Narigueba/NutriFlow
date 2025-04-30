namespace NutriFlowAPI.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        
        public ICollection<EstoqueAlimento> Estoque { get; set; }
    }
}
