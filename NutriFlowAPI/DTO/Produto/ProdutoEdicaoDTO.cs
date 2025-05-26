using Microsoft.Identity.Client;

namespace NutriFlowAPI.DTO.Produto
{
    public class ProdutoEdicaoDTO
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public bool Ativo {  get; set; }
        public IFormFile? Imagem { get; set; }

    }
}
