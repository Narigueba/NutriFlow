namespace NutriFlowAPI.DTO.Produto
{
    public class ProdutoCriacaoDTO
    {
        public string Produto {  get; set; }
        public bool Ativo {  get; set; }
        public IFormFile? Imagem { get; set; }

    }
}
