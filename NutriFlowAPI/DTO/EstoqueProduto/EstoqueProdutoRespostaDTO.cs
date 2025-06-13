namespace NutriFlowAPI.DTO.EstoqueProduto
{
    public class EstoqueProdutoRespostaDTO
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeProduto { get; set; }
        public string NomeCategoria { get; set; }
        public string NomeMarca { get; set; }
        public decimal Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public decimal Preco { get; set; }
        public string NomeEstabelecimento { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataValidade { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
